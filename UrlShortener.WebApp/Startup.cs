using System;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using UrlShortener.Commands.AddNewShortLinkOrGetExisting;
using UrlShortener.Contracts;
using UrlShortener.Dal;
using UrlShortener.Queries.GetSourceUrlByShortenedUrl;
using UrlShortener.WebApp.Helpers;
using AddNewShortLinkOrGetExistingMapperProfile = UrlShortener.Commands.AddNewShortLinkOrGetExisting.MapperProfile;
using GetSourceUrlByShortenedUrlMapperProfile = UrlShortener.Queries.GetSourceUrlByShortenedUrl.MapperProfile;

namespace UrlShortener.WebApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration["Data:DefaultConnection:ConnectionString"];
            services.AddDbContext<UrlShortenerDb>(options => options.UseSqlServer(connection));

            // Add framework services.
            services.AddMvc();

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.AddScoped<IRequestUrlProvider, RequestUrlProvider>();

            services.AddMediatR(typeof(Command), typeof(Query));
            services.AddAutoMapper(typeof(AddNewShortLinkOrGetExistingMapperProfile),
                typeof(GetSourceUrlByShortenedUrlMapperProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.MigrateDatabase();

            app.UseStaticFiles();

            app.UseCors(o => o
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
                .AllowCredentials()
                .SetPreflightMaxAge(TimeSpan.FromSeconds(2520))
            );

            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "short",
                    template: "{shortenedUrl:required}",
                    defaults: new {controller = "Home", action = "RedirectToUrl"}
                );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}