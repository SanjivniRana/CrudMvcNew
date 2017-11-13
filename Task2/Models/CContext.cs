using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Task2.Models
{

    public class CContext : DbContext
    {
        public CContext() : base("name=connect")
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CCountry> CCountries { get; set; }
        public DbSet<CState> CStates { get; set; }

    }
}