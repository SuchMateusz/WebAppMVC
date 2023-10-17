using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Domain.Interface;
using Type = WebAppMVC.Domain.Model.Type;

namespace WebAppMVC.Infrastructure.Repositories
{
    public class TypesRepository : ITypesRepository
    {
        private readonly Context _context;

        public TypesRepository(Context context)
        {
            _context = context;
        }

        public int AddType(Type type)
        {
            _context.Types.Add(type);
            _context.SaveChanges();
            return type.Id;
        }

        public void DeleteType(int typeId)
        {
            var type = _context.Types.FirstOrDefault(p => p.Id == typeId);
            if (type != null)
            {
                _context.Types.Remove(type);
                _context.SaveChanges();
            }
        }

        public IQueryable<Type> GetAllTypes()
        {
            var types = _context.Types;
            return types;
        }

        public void EditType(Type type)
        {
            _context.Attach(type);
            _context.Entry(type).Property("Name").IsModified = true;
            _context.Entry(type).Property("ItemId").IsModified = true;
            _context.SaveChanges();
        }

        public Type GetTypeById(int typeId)
        {
            var type = _context.Types.FirstOrDefault(p => p.Id == typeId);
            return type;
        }

    }
}
