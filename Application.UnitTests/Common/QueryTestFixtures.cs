using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Application.Mapping;
using WebAppMVC.Infrastructure;

namespace Application.UnitTests.Common
{
    public class QueryTestFixtures
    {
        public Context Context { get; private set; }

        public IMapper Mapper { get; private set; }

        public QueryTestFixtures()
        {
            Context = DbContextFactory.Create().Object;
            var configurationProvider = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());

            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            DbContextFactory.Destroy(Context);
        }

        [CollectionDefinition("QueryCollection")]
        public class QueryCollection : ICollectionFixture<QueryCollection> 
        {
            
        }
    }
}