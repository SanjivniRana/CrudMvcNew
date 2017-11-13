using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task2.Models
{
    public class CState
    {
        [Key]
        public int StateId { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}