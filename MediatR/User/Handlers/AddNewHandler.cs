using MediatR;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TZTDate_IdentityWebApi.MediatR.User.Commands;
using TZTDate_IdentityWebApi.Data;
using TZTDate_IdentityWebApi.Models;
using TZTDate_IdentityWebApi.Services.Base;
using TZTDate_IdentityWebApi.Enums;

namespace TZTDate_IdentityWebApi.MediatR.User.Handlers;

public class AddNewHandler : IRequestHandler<AddNewCommand>
{
    private readonly TZTDateDbContext tZTDateDbContext;
    private readonly ISender sender;
    private readonly IAzureBlobService azureBlobService;
    private readonly IInterestsService interestsService;

    public AddNewHandler(TZTDateDbContext tZTDateDbContext, ISender sender, IAzureBlobService azureBlobService, IInterestsService interestsService)
    {
        this.azureBlobService = azureBlobService;
        this.interestsService = interestsService;
        this.tZTDateDbContext = tZTDateDbContext;
        this.sender = sender;
    }

    public async Task Handle(AddNewCommand request, CancellationToken cancellationToken)
    {
        if (request.UserRegisterDto is null)
        {
            throw new ArgumentNullException($"{nameof(request.UserRegisterDto)} cannot be null");
        }

        var result = await sender.Send(new FindByEmailCommand
        {
            Email = request.UserRegisterDto.Email
        });

        if (result is not null)
        {
            throw new ArgumentNullException($"{request.UserRegisterDto.Email} already exists");
        }

        var address = new Address
        {
            City = request.UserRegisterDto.City,
            Country = request.UserRegisterDto.Country,
            State = request.UserRegisterDto.State,
        };

        await tZTDateDbContext.Addresses.AddAsync(address);

        var imagePaths = new List<string>();

        var type = request.UserRegisterDto.GetType();
        PropertyInfo[] properties = type.GetProperties();

        foreach (PropertyInfo property in properties)
        {
            if (property.Name.Contains("Image") && !property.Name.Contains("Name"))
            {
                var filename = string.Empty;
                foreach (var property2 in properties)
                {
                    if (property2.Name == property.Name + "Name")
                    {
                        filename = property2.GetValue(request.UserRegisterDto).ToString() + request.UserRegisterDto.Email + Guid.NewGuid().ToString() + ".jpg";
                        break;
                    }
                }
                byte[] fileBytes = Convert.FromBase64String(property.GetValue(request.UserRegisterDto).ToString());
                using var memoryStream = new MemoryStream(fileBytes);
                await azureBlobService.UploadFile(memoryStream, filename);

                imagePaths.Add(filename);

            }
        }

        if (await tZTDateDbContext.Users.FirstOrDefaultAsync(x => x.Username == request.UserRegisterDto.Username) is not null)
        {
            throw new ArgumentException("Username already taken");
        }

        var user = new Models.User
        {
            Username = request.UserRegisterDto.Username,
            Email = request.UserRegisterDto.Email,
            BirthDateTime = request.UserRegisterDto.BirthDateTime,
            CreatedAt = DateTime.Now,
            Description = request.UserRegisterDto.Description,
            Address = address,
            Gender = request.UserRegisterDto.Gender,
            ProfilePicPaths = imagePaths.ToArray(),
            SearchingGender = request.UserRegisterDto.SearchingGender,
            SearchingAgeStart = request.UserRegisterDto.SearchingAgeStart,
            SearchingAgeEnd = request.UserRegisterDto.SearchingAgeEnd,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.UserRegisterDto.Password),
        };


        await tZTDateDbContext.Users.AddAsync(user);
        await tZTDateDbContext.SaveChangesAsync();

        await interestsService.SetInterestsAsync(user.Id, request.UserRegisterDto.Interests);

        var role = await tZTDateDbContext.Roles.FirstOrDefaultAsync(r => r.Name == UserRoles.User.ToString());
        if (role == null)
        {
            throw new ArgumentException($"Role does not exist with {UserRoles.User} name");
        }

        var userRole = new UserRole { User = user, Role = role };
        await tZTDateDbContext.UserRoles.AddAsync(userRole);

        await tZTDateDbContext.SaveChangesAsync();
    }
}