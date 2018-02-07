using System.Data.Entity;
using Evidence.DTO;

namespace Evidence.BLL
{
    public class ProductsViewManager:ReadManager<ProductView>
    {
        public ProductsViewManager(DbContext db) : base(db)
        {
        }
    }
}
