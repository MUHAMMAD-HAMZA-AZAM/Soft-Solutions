using Soft_Solutions.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Soft_Solutions.ViewModels
{
    public class CustomerViewModel
    {
        public CustomerViewModel()
        {
            CitiesList = new List<City>();
        }

        public int CustomerId { get; set; }

        [Required(ErrorMessage ="* Enter Your  Name  ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*Select Gender  ")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "*Enter Details  ")]
        public string Details { get; set; }

        public DateTime RegistrationDate { get; set; }

        public int CityId { get; set; }

        [Required(ErrorMessage = "*Select City ")]
        public string CityName { get; set; }

        [Display(Name =" City ")]
        [Required(ErrorMessage = "*Select City ")]
        public List<City> CitiesList { get; set; }



    }
}