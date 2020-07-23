using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Soft_Solutions.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        [Required]
        [Display(Name =" City Name ")]
        public string CityName { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}