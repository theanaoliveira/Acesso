using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Linq;

namespace TestAcesso.Webapi.DependencyInjection
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.OperationFilter<AnnotationsOperationFilter>();
                options.CustomOperationIds(e => $"{e.ActionDescriptor.RouteValues["controller"]}_{e.ActionDescriptor.RouteValues["action"]}");
            });

            return services;
        }

        public static IApplicationBuilder UseVersionedSwagger(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            var versions = provider.ApiVersionDescriptions.ToList();
            
            app.UseSwagger(c =>
            {
                c.PreSerializeFilters.Add((document, request) =>
                {
                    document.Servers.Add(new OpenApiServer { Url = $"{HostResolve(request)}" });
                });
            });

            app.UseSwaggerUI(options =>
            {
                versions.ForEach(description =>
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                });

                options.DefaultModelsExpandDepth(-1);
            });

            return app;
        }

        private static string ExtractHost(HttpRequest request) =>
            request.Headers.ContainsKey("X-Forwarded-Host") ?
                new Uri($"{ExtractProto(request)}://{request.Headers["X-Forwarded-Host"].First()}").Host :
                    request.Host.ToString();

        private static string ExtractProto(HttpRequest request) =>
            request.Headers["X-Forwarded-Proto"].FirstOrDefault() ?? request.Protocol;

        private static string ExtractPath(HttpRequest request) =>
            request.Headers.ContainsKey("X-Forwarded-Prefix") ?
                request.Headers["X-Forwarded-Prefix"].FirstOrDefault() :
                string.Empty;

        private static bool ContainsXFoward(HttpRequest request) => request.Headers["X-Forwarded-Proto"].Any();

        private static string HostResolve(HttpRequest request)
        {
            if (ContainsXFoward(request))
                return $"https://{ExtractHost(request)}{ExtractPath(request)}/";
            else
                return $"http://{ExtractHost(request)}";
        }
    }
}
