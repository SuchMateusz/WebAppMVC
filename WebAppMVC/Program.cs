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

namespace WebAppMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<Context>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<Context>();

            builder.Services.AddApplication();
            builder.Services.AddInfrastructure();

            builder.Services.AddControllersWithViews().AddFluentValidation();

            builder.Services.AddTransient<IValidator<NewCustomerVM>, NewCustomerValidation>();
            builder.Services.AddTransient<IValidator<AddressForListVM>, NewAddressValidation>();
            builder.Services.AddTransient<IValidator<ItemForListVM>, ItemValidation>();

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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}