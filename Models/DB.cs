using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShopMVC.Models
{
    public class DB : DbContext
    {
        public DB():
            base("DBShop")
        {  }
        public DbSet<ProductsDTO> productsDTO { get; set; }
        public DbSet<ZakazDTO> ZakazDTO { get; set; }
        public DbSet<SootDTO> SootDTO { get; set; }
    }
}