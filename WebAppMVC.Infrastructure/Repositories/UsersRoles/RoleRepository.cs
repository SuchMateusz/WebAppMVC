using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Domain.Interfaces.Users_Roles;
using WebAppMVC.Domain.Models.Common;

namespace WebAppMVC.Infrastructure.Repositories.Users_Roles
{
    public class RoleRepository : IRoleRepository
    {
        private readonly Context _context;

        public RoleRepository(Context context)
        {
            _context = context;
        }

        public ApplicationRole GetRole(string roleName)
        {
            return _context.Roles.FirstOrDefault(p => p.Name == roleName);
        }

        public ICollection<ApplicationRole> GetRoles()
        {
            return _context.Roles.ToList();
        }
    }
}
