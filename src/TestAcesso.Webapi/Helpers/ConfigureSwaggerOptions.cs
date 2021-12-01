using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace TestAcesso.Webapi.Helpers
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        readonly IApiVersionDescriptionProvider provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
            => this.provider = provider;

        public void Configure(SwaggerGenOptions options)
            => provider.ApiVersionDescriptions.ToList().ForEach(description => options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description)));

        static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                Title = "TestAcesso",
                Version = description.ApiVersion.ToString(),
                Description = "",
            };

            if (description.IsDeprecated)
                info.Description += " - This API version has been deprecated.";

            return info;
        }
    }
}
