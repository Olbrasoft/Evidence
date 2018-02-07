using System.Data.Entity;
using Evidence.DTO;

namespace Evidence.BLL
{
    public class CategoriesManager : Manager<Category>
    {
        public CategoriesManager(DbContext db) : base(db)
        {
        }
    }
}
