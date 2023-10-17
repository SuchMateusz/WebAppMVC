using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = WebAppMVC.Domain.Model.Type;

namespace WebAppMVC.Domain.Interface
{
    public interface ITypesRepository
    {
        public int AddType(Type type);

        public Type GetTypeById(int typeId);

        public void DeleteType(int typeId);

        public IQueryable<Type> GetAllTypes();

        void EditType(Type type);
    }
}
