using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopMVC.Models
{
    [Table("Product")]
    public class ProductsDTO
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Prise { get; set; }
        public int Kol { get; set; }
        public string Opis { get; set; }
    }
}