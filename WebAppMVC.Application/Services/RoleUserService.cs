using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Domain.Interfaces.Users_Roles;
using WebAppMVC.Domain.Models.Common;

namespace WebAppMVC.Infrastructure.Repositories.Users_Roles
{
    public class RoleUserService : IRoleUserService
    {
        public IUserRepository User { get; }
        
        public IRoleRepository Role { get; set; }

        public RoleUserService(IUserRepository user, IRoleRepository role)
        {
            User = user;
            Role = role;
        }

        public IdentityRole GetRole(string name)
        {
            var model = Role.GetRole(name);
            return model;
        }
    }
}