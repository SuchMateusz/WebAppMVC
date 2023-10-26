using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppMVC.Domain.Interfaces.Users_Roles
{
    public interface IRoleUserService
    {
        IUserRepository User { get; }

        IRoleRepository Role { get; set; }
    }
}