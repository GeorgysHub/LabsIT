using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopMVC.Models
{[Table("Zakaz")]
    public class ZakazDTO
    {
        
       
            [Key]
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Lastname { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public decimal TotalPrise { get; set; }

    }
}