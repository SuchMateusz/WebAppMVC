using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.Interfaces;
using WebAppMVC.Domain.Interface;
using WebAppMVC.Domain.Interfaces.Users_Roles;
using WebAppMVC.Infrastructure.Repositories;
using WebAppMVC.Infrastructure.Repositories.Users_Roles;

namespace WebAppMVC.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IAlcoholRepository, AlcoholRepository>();
            services.AddTransient<IAddressesRepository, AddressesRepository>();
            services.AddTransient<IAlcoCategorysRepository, AlcoCategorysRepository>(); 
            services.AddTransient<IAlcoDescriptionsRepository, AlcoDescriptionsRepository>();
            services.AddTransient<IAlcoIngredientRepository, AlcoIngredientRepository>(); 
            services.AddTransient<ICustContInfoRepository, CustContInfoRepository>();
            services.AddTransient<IIngredientRepository, IngredientRepository>(); 
            services.AddTransient<ITagsRepository, TagsRepository>();
            services.AddTransient<ITypesRepository, TypesRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            return services;
        }
    }
}