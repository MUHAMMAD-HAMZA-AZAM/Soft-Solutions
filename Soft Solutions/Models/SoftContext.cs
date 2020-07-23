using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace Soft_Solutions.Models
{
    public class SoftContext : DbContext
    {
        public SoftContext() : base("name = SoftContext")
        {
            
        }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<City> Cities { get; set; }

    }
}