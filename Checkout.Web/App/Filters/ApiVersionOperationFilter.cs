using System.Linq;
using Checkout.Web.App.Extensions;

using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Checkout.Web.App.Filters
{
    /// <summary>
    /// To check the content type values passed from the SwaggerConsumerAttribute decorator, and
    /// To add all content types passed from the decorator to operation.consumes.
    /// </summary>
    public class ApiVersionOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            var actionApiVersionModel = context.ApiDescription.ActionDescriptor?.GetApiVersion();

            if (actionApiVersionModel == null) return;

            if (actionApiVersionModel.DeclaredApiVersions.Any())
            {
                operation.Produces = operation.Produces
                .SelectMany(p => actionApiVersionModel.DeclaredApiVersions
                .Select(version => $"{p};v={version.ToString()}"))
                .ToList();
            }
            else
            {
                operation.Produces = operation.Produces
                .SelectMany(p => actionApiVersionModel.ImplementedApiVersions.OrderByDescending(v => v)
                .Select(version => $"{p};v={version.ToString()}"))
                .ToList();
            }
        }
    }
}