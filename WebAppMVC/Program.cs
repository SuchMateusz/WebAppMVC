using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebAppMVC.Application.Interfaces;
using WebAppMVC.Infrastructure;
using WebAppMVC.Application;
using FluentValidation.AspNetCore;
using FluentValidation;
using WebAppMVC.Application.ViewModel.Customer;
using System.ComponentModel.DataAnnotations;
using Serilog;
using WebAppMVC.Application.ViewModel.Item;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Configuration;
using Microsoft.Extensions.Options;
using WebAppMVC.Domain.Models.Common;

namespace WebAppMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            var configuration = builder.Configuration;
            builder.Services.AddDbContext<Context>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<Context>();

            builder.Services.AddRazorPages();
            builder.Services.AddApplication();
            builder.Services.AddInfrastructure();
            builder.Services.AddControllersWithViews().AddFluentValidation(fv => fv.DisableDataAnnotationsValidation = true);

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredUniqueChars = 1; ;
                options.Password.RequiredLength = 8;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireDigit = true;

                options.SignIn.RequireConfirmedEmail = false;
                options.User.RequireUniqueEmail = true;
            });

            builder.Services.AddAuthentication()
                .AddGoogle(googleOptions => 
                {
                    IConfigurationSection googleAuthNSection = configuration.GetSection("Authentication:Google");
                    googleOptions.ClientId = googleAuthNSection["ClientId"];
                    googleOptions.ClientSecret = googleAuthNSection["ClientSecret"];
                })
                .AddFacebook(facebookOptions => {
                    facebookOptions.AppId = configuration["Authentication:Facebook:AppId"];
                    facebookOptions.AppSecret = configuration["Authentication:Facebook:AppSecret"];
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            var loggerFactory = app.Services.GetService<ILoggerFactory>();
            loggerFactory.AddFile("Logs/myLog-{Date}.txt");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();

        }
    }
}