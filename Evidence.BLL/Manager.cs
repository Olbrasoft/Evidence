using System.Data.Entity;
using Evidence.DTO;

namespace Evidence.BLL
{
    public class Manager<T> : ReadManager<T>, IManager<T> where T : Entity
    {
        public Manager(DbContext db) : base(db)
        {
        }

        public void Save(T entity)
        {
            Db.Entry(entity).State = entity.Id != 0 ? EntityState.Modified : EntityState.Added;
            Db.SaveChanges();
        }

        public void Delete(int id)
        {
            Db.Set<T>().Remove(Get(id));
            Db.SaveChanges();
        }
    }
}
