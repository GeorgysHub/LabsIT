using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopMVC.Models
{
    public class ZakazVM1
    {
        public ZakazVM1()
        {

        }
        public ZakazVM1(ZakazDTO row)
        {
            Id = row.Id;
            Name = row.Name;
            Surname = row.Surname;
            Lastname = row.Lastname;
            Phone = row.Phone;
            Email = row.Email;
            TotalPrise = row.TotalPrise;
        }
       
            
            public int Id { get; set; }
        [Required]
        [DisplayName("Имя")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Фамилия")]
        public string Surname { get; set; }
        [Required]
        [DisplayName("Отчество")]
        public string Lastname { get; set; }
        [Required]
        [DisplayName("Телефон")]
        public string Phone { get; set; }
            public string Email { get; set; }
        [Required]
        [DisplayName("Общая цена товара")]
        public decimal TotalPrise { get; set; }

    }
}