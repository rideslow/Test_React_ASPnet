using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tess_React_ASPnet.DAL;
using Tess_React_ASPnet.DAL.Interfaces;
using Tess_React_ASPnet.DAL.Repositories;
using Test_React_ASPnet.Domain.Mappings;
using Test_React_ASPnet.Service.Implementations;
using Test_React_ASPnet.Service.Interfaces;

namespace Test_React_ASPnet
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ITool_UserRepository, Tool_UserRepository>();
            services.AddScoped<IToolRepository, ToolRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITool_UserService, Tool_UserService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IToolService, ToolService>();

            services.AddAutoMapper(typeof(Maps));

            services.AddControllers().AddNewtonsoftJson();
            services.AddControllersWithViews();

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "client/build";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error"); 
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            SeedData.Seed(db);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "client";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
