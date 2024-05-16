using Microsoft.AspNetCore.ResponseCompression;

namespace TZTDate.IdentityWebApi.Extensions;

public static class ResponseCompressionExtension
{
    public static void InitResponse(this IServiceCollection serviceCollecyion)
    {
        serviceCollecyion.AddResponseCompression(opts => { 
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes
                .Concat(new[] { "application/octet-stream" }); 
            });
    }
}
