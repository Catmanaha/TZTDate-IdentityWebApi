using System.Reflection;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using TZTDate_IdentityWebApi.Data;
using TZTDate_IdentityWebApi.Enums;
using TZTDate_IdentityWebApi.Extensions;
using TZTDate_IdentityWebApi.Middlewares;
using TZTDate_IdentityWebApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddResponseCompression(opts =>
{
  opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(["application/octet-stream"]);
});

builder.Services.InitResponse();
builder.Services.Inject();
builder.Services.InitSwagger();
builder.Services.InitAuthentication(builder.Configuration);
builder.Services.Configure(builder.Configuration);
builder.Services.InitDbContext(builder.Configuration, Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(configurations => configurations.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddAuthorization();


builder.Services.AddCors(options =>
{
  options.AddPolicy("BlazorWasmPolicy", corsBuilder =>
  {
    corsBuilder
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
  });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
  var context = scope.ServiceProvider.GetRequiredService<TZTDateDbContext>();
  await context.Database.MigrateAsync();
  await context.Database.EnsureCreatedAsync();

  var userRoleExists = await context.Roles.AnyAsync(r => r.Name == "User");
  var adminRoleExists = await context.Roles.AnyAsync(r => r.Name == "Admin");

  if (!userRoleExists)
  {
    var userRole = new Role { Name = UserRoles.User.ToString() };
    await context.Roles.AddAsync(userRole);
  }

  if (!adminRoleExists)
  {
    var adminRole = new Role { Name = UserRoles.Admin.ToString() };
    await context.Roles.AddAsync(adminRole);
  }

  await context.SaveChangesAsync();
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapDefaultControllerRoute();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("BlazorWasmPolicy");
app.UseResponseCompression();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();
