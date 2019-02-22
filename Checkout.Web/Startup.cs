using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Checkout.BusinessLogic;
using Checkout.Web.App.Extensions;
using Checkout.Web.App.Filters;
using Checkout.Web.App.Middleware;

namespace Checkout.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationServices();
            services.AddMvc(options =>
            {
                options.MaxModelValidationErrors = 50;
                options.Filters.Add(typeof(ModelStateValidationFilterAttribute));
            });

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConfiguration(Configuration.GetSection("Logging"));
                loggingBuilder.AddConsole();
                loggingBuilder.AddDebug();
            });

            services.AddApiVersioningAndDocs();
            services.AddMemoryCache();
            services.AddAutoMapper(typeof(ApplicationMappingProfile));

            return services.AddDb();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            Configure(app, env);

            app.UseMiddleware(typeof(ApiErrorHandlingMiddleware));
            app.UseStaticFiles();
            app.UseMvcRoutes();
            app.UseApiDocumentation();
        }

        /// <summary>
        /// Configure based on environment
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
        }
    }
}
