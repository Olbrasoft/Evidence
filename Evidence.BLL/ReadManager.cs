using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Evidence.DTO;

namespace Evidence.BLL
{
    public class ReadManager<T> : IReadManager<T> where T : Entity
    {
        protected readonly DbContext Db;

        public ReadManager(DbContext db)
        {
            Db = db;
        }

        public T Get(int id)
        {
            return Db.Set<T>().Find(id);
        }

        public IEnumerable<T> Get()
        {
            return Db.Set<T>();
        }
        
        public IEnumerable<T> Get(int page, int size, Func<IQueryable<T>, IQueryable<T>> filterAndSort, out int pageCount)
        {
            var result = filterAndSort(Db.Set<T>());
            var rowCount = result.Count();
            pageCount = (int)Math.Ceiling(rowCount / (double)size);
            return result.Skip((page - 1) * size).Take(size);
        }
    }


}
