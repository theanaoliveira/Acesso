using Autofac;
using Autofac.Configuration;
using Autofac.Extensions.DependencyInjection;
using Hellang.Middleware.ProblemDetails;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;
using System;
using TestAcesso.Webapi.DependencyInjection;

namespace TestAcesso.Webapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var builder = new ContainerBuilder();

            services.AddLocalization();
            services.AddVersioning();
            services.AddProblemDetails();
            services.AddSwagger();
            services.AddMvc(options => options.EnableEndpointRouting = false)
               .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
               .AddNewtonsoftJson(options =>
               {
                   options.SerializerSettings.Converters.Add(new StringEnumConverter());
                   options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
               });
            services.AddSwaggerGenNewtonsoftSupport();

            builder.AddAutofacRegistration();
            builder.Populate(services);

            var container = builder.Build();
            var bus = container.Resolve<IBusControl>();

            bus.Start();

            return new AutofacServiceProvider(container);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            app.AddLocalization();
            app.UseCors();
            app.UseProblemDetails();
            app.UseVersionedSwagger(provider);
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(e => e.MapControllers());
        }
    }
}
