using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task2.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }



        [Required(ErrorMessage = "FirstName is required")]
        [Display(Name = "Firstname")]
        [StringLength(50, ErrorMessage = "length should not be more than 50 characters")]
        public string Firstname { get; set; }




        [Required(ErrorMessage = "LastName is required")]
        [Display(Name = "LastName")]
        [StringLength(20, ErrorMessage = "length should not be more than 20 characters")]
        public string Lastname { get; set; }



        //[RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
        //ErrorMessage = "Please enter correct email address")]
        public string Email { get; set; }



        [Required(ErrorMessage = "Contact is required")]
        //[Display(Name = "Contact No")]
        //[RegularExpression(@"/(^\(\d{10})?)$/", ErrorMessage = "Please enter proper contact details.")]
        public string Contact { get; set; }



        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Address ")]
        [StringLength(20, ErrorMessage = "length should not be more than 200 characters")]
        public string Address { get; set; }



        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }



        [Required(ErrorMessage = "Pincode is required")]
        //[Display(Name = "Pincode ")]
        //[RegularExpression(@"/(^\(\d{10})?)$/", ErrorMessage = "Please enter proper Pincode details.")]
        public string Pincode { get; set; }

        public string length { get; set; }
    }
}