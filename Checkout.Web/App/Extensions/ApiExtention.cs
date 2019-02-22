using System;
using System.IO;
using System.Linq;
using Checkout.Web.App.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Checkout.Web.App.Extensions
{
    /// <summary>
    /// Configuration of Swagger
    /// Ref: https://swagger.io/
    /// Ref: https://github.com/domaindrivedev/Swashbuckle.AspNetCore/blob/master/README.md
    /// Ref: https://blog.jimsmith.me/blogs/api-versioning-in-aspnet-core-with-nice-swagg
    /// </summary>
    public static class ApiExtention
    {
        public static IServiceCollection AddApiVersioningAndDocs(this IServiceCollection services)
        {
            var baseXmlDir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

            //Set the versioning
            return services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0); //default api version
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ApiVersionReader = new MediaTypeApiVersionReader(); //read the version number from the accept header
            })

            //Set the swagger api documentation generation
            .AddSwaggerGen(options =>
            {
                //General doc info
                options.SwaggerDoc("v1.0", GetInfo());

                options.DocInclusionPredicate((docName, apiDesc) =>
                {
                    var actionApiVersionModel = apiDesc.ActionDescriptor?.GetApiVersion();

                    //This would mean that this action is unversioned and should be included everywhere
                    if (actionApiVersionModel == null)
                    {
                        return true;
                    }

                    if (actionApiVersionModel.DeclaredApiVersions.Any())
                    {
                        return actionApiVersionModel.DeclaredApiVersions.Any(v => $"v{v.ToString()}" == docName);
                    }

                    return actionApiVersionModel.ImplementedApiVersions.Any(v => $"v{v.ToString()}" == docName);
                });

                options.OperationFilter<ApiVersionOperationFilter>();

                //Add the xml comment files for documentation
                foreach (var fi in baseXmlDir.EnumerateFiles("*.xml"))
                {
                    options.IncludeXmlComments(fi.FullName);
                }
            });
        }

        private static Info GetInfo()
        {
            return new Info
            {
                Title = "Checkout.com Shopping Cart API",
                Version = "v1.0",
                Contact = GetContactInfo(),
                Description = "Checkout.com Shopping Cart prototype RestFul API. Use version '1.0' OR '1' where asked"
            };
        }

        private static Contact GetContactInfo()
        {
            return new Contact
            {
                Email = "vinod.malvi@yahoo.co.uk",
                Name = "Vinnie Malvi"
            };
        }

        public static IApplicationBuilder UseApiDocumentation(this IApplicationBuilder app)
        {
            return app
            .UseSwagger()
            .UseSwaggerUI(c =>
            {
                //Add more versions as required
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Versioned API v1.0");
            });
        }
    }
}