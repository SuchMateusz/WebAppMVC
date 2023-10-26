using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Domain.Models.Common;

namespace WebAppMVC.Domain.Interfaces.Users_Roles
{
    public interface IRoleRepository
    {
        ICollection<ApplicationRole> GetRoles();

        ApplicationRole GetRole(string roleName);
    }
}
