//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using WebAppMVC.Domain.Interfaces.Common;
//using WebAppMVC.Domain.Model;
//using WebAppMVC.Domain.Model.Common;

//namespace WebAppMVC.Infrastructure.Repositories.Common
//{
//    public class BaseRepository<T> : IBaseRepository<T> where T : class
//    {

//        private readonly Context _context;
//        private readonly DbSet<T> _dbSet;

//        public BaseRepository(Context context)
//        {
//            _context = context;
//            this._dbSet = context.Set<T>();
//        }

//        public void AddNewObject(T obj)
//        {
//            _dbSet.Add(obj);
//            _context.SaveChanges();
//        }

//        public void DeleteObject(T obj)
//        {
//            var alcohol = _dbSet.Find(obj.Id);
//            if (alcohol != null)
//            {
//                _dbSet.Remove(alcohol);
//                _context.SaveChanges();
//            }
//        }

//        public void EditObject(T obj)
//        {
//            throw new NotImplementedException();
//        }

//        public IQueryable<T> GetAll()
//        {
//            var list = _dbSet;
//            return list;
//        }

//        public T GetById(int id)
//        {
//            return _dbSet.Find(id);
//        }

//        public void UpdateObject(T obj)
//        {
//            _dbSet.Attach(obj);
//            _context.Entry(obj).State = EntityState.Modified;
//        }
//    }
//}
