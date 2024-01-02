using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.Interfaces;
using WebAppMVC.Application.Services;
using WebAppMVC.Application.ViewModel.Customer;
using WebAppMVC.Application.ViewModel.Item;
using WebAppMVC.Domain.Interfaces.Users_Roles;
using WebAppMVC.Infrastructure.Repositories.Users_Roles;
using static WebAppMVC.Application.ViewModel.Customer.CustomerContactInformactionForListVm;

namespace WebAppMVC.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IAlcoholService, AlcoholService>();
            services.AddTransient<IIngredientsService, IngredientsService>();
            services.AddTransient<IMarkAlcoholService, MarkAlcoholService>();
            services.AddScoped<IRoleUserService, RoleUserService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient<IValidator<NewCustomerVM>, NewCustomerValidation>();
            services.AddTransient<IValidator<AddressForListVM>, NewAddressValidation>();
            services.AddTransient<IValidator<CustomerContactInformactionForListVm>, NewCustomerContactInformactionValidation>();
            services.AddTransient<IValidator<IngredientForListVM>, NewIngredientValidation>();
            services.AddTransient<IValidator<AlcoholIngredientsForListVM>, AlcoholIngredientsValidation>();
            services.AddTransient<IValidator<NewAlcoholForListVM>, NewAlcoholValidation>();
            services.AddTransient<IValidator<AlcoholForListVM>, AlcoholValidation>();
            services.AddTransient<IValidator<TypeForListVM>, NewTypeValidation>();
            services.AddTransient<IValidator<TagForListVM>, NewTagValidation>();
            services.AddTransient<IValidator<CategoryForListVM>, NewCategoryValidation>();
            services.AddTransient<IValidator<DescriptionForListVM>, NewDescriptionValidation>();
            return services;
        }
    }
}