using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopMVC.Models
{
    public class SootvVM
    {
        public SootvVM()
        {

        }
        public SootvVM(SootDTO row)
        {
            Id = row.Id;
            Zakaz = row.Zakaz;
            Tovar = row.Tovar;
            Kol = row.Kol;
        }
        public int Id { get; set; }
        public int Zakaz { get; set; }
        public int Tovar { get; set; }
        public int Kol { get; set; }
    }
}