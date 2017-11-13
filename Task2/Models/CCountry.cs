using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task2.Models
{
    public class CCountry
    {
        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
}