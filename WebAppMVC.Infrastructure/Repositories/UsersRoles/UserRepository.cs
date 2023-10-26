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
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public ICollection<ApplicationUser> GetUsers()
        {
            var users = new List<ApplicationUser>();
            return _context.Users.ToList();
        }

        public ApplicationUser GetUser(string id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public ApplicationUser UpdateUser(ApplicationUser user)
        {
            _context.Update(user);
            _context.SaveChanges();
            return user;
        }
    }
}