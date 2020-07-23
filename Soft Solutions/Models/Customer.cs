using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Soft_Solutions.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = " Customer Name ")]
        public string Name { get; set; }
        [Required]
        [Display(Name = " Gender ")]
        public string Gender { get; set; }

        [Display(Name = " Details ")]
        public string Details { get; set; }

        public DateTime RegistrationDate { get; set; }

        public int? CityId { get; set; }
        public virtual City City { get; set; }
    }
}