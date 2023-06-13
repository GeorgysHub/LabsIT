using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ShopMVC.Models
{
    public class CardVM
    {
        public int ProductID { get; set; }
        [DisplayName("Название")]
        public string ProductName { get; set; }
        [DisplayName("Колличество")]
        public int Quantity { get; set; }
        [DisplayName("Цена")]
        public decimal Prise { get; set; }
        [DisplayName("Полная Цена")]
        public decimal TotalPrise
        {
            get { return Quantity * Prise; }
            
        }
    }
}