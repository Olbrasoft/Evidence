using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Evidence.DAL;
using Evidence.DTO;

namespace Evidence.BLL
{
    public class ProductsManager : Manager<Product>
    {
        public ProductsManager(DbContext db) : base(db)
        {
        }
    }
}
