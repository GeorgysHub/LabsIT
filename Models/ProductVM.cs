using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopMVC.Models
{
    public class ProductVM
    {
        public ProductVM()
        {

        }
        public ProductVM(ProductsDTO row)
        {
            Id = row.Id;
            Name = row.Name;
            Prise = row.Prise;
            Kol = row.Kol;
            Opis = row.Opis;
        }
        public int Id { get; set; }
        [Required]
        [DisplayName("Название")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Цена")]
        public decimal Prise { get; set; }
        [Required]
        [DisplayName("Наличие")]
        public int Kol { get; set; }
        [Required]
        [StringLength(50 , MinimumLength = 1)]
        [DisplayName("Описание")]
        public string Opis { get; set; }
    }
}