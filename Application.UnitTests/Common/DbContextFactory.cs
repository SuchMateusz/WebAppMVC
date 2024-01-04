using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Infrastructure;

namespace Application.UnitTests.Common
{
    public class DbContextFactory
    {
        public static Mock<Context> Create()
        {
            //var options = new DbContextOptionsBuilder<Context>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var mock = new Mock<Context>();
            var context = mock.Object;
            context.Database.EnsureCreated();
            context.SaveChanges();

            return mock;
        }

        public static void Destroy(Context context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
