using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopMVC.Models
{
    public class UserM
    {
        [Required]
        [DisplayName("Имя Пользователя")]
        public string Username { get; set; }
        [Required]
        [DisplayName("Пароль")]
        public string Password { get; set; }
        public bool Rememder { get; set; }
    }
}