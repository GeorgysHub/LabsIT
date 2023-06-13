using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopMVC.Models
{
    [Table("Sootv")]
    public class SootDTO
    {
        [Key]
        public int Id { get; set; }
        public int Zakaz { get; set; }
        public int Tovar { get; set; }
        public int Kol { get; set; }

    }
}