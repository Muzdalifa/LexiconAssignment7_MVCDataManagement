using LexiconAssignment7_MVCDataManagement.Data;
using LexiconAssignment7_MVCDataManagement.Models;
using LexiconAssignment7_MVCDataManagement.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
//using System.Text.Json.Serialization;

namespace LexiconAssignment7_MVCDataManagement
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddScoped<IPeopleRepo, InMemoryPeopleRepo>();
            services.AddScoped<IPeopleRepo, DatabasePeopleRepo>();
            services.AddScoped<IPeopleService, PeopleService>();

            services.AddScoped<ICityRepo, DatabaseCityRepo>();
            services.AddScoped<ICityService, CityService>();

            services.AddScoped<ICountryRepo, DatabaseCountryRepo>();
            services.AddScoped<ICountryService, CountryService>();

            services.AddScoped<ILanguageRepo, DatabaseLanguageRepo>();
            services.AddScoped<ILanguageService, LanguageService>();

            services.AddScoped<IPersonLanguageRepo, DatabasePersonLanguageRepo>();

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddDefaultTokenProviders()
                .AddDefaultUI()
                .AddEntityFrameworkStores<PeopleDbContext>();

            services.AddDbContext<PeopleDbContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("PeopleDb"));
            });
            services.AddControllers();
            services.AddMvc().AddJsonOptions(o =>
            {
                o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                o.JsonSerializerOptions.MaxDepth = 0;
            });
            //Configure CORS 
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("*")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=People}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "custom",
                    pattern: "{controller=ajax}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                   name: "frontEnd",
                   pattern: "{controller=ReactFrontend}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
