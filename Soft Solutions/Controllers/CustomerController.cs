using Soft_Solutions.Models;
using Soft_Solutions.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Soft_Solutions.Controllers
{
    public class CustomerController : Controller
    {
        SoftContext _context = new SoftContext();
        // GET: Customer
        public ActionResult Index()
        {
            var customerlist = _context.Customers.ToList();
            return View(customerlist);
        }

        [HttpGet]
        public ActionResult AddCustomer()
        {
            var citylist = _context.Cities.ToList();
            var model = new CustomerViewModel
            {
                CitiesList = citylist
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult AddCustomer( CustomerViewModel customerViewModel)
        {
            Customer ObjCustomer = new Customer
            {
                Name = customerViewModel.Name,
                Gender = customerViewModel.Gender,
                Details = customerViewModel.Details,
                RegistrationDate = DateTime.Now,
                CityId=customerViewModel.CityId

            };
            _context.Customers.Add(ObjCustomer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {

            int ID = Convert.ToInt32(id);
            var result = _context.Customers.Where(c => c.Id == ID).FirstOrDefault();
            var citylist = _context.Cities.ToList();
            CustomerViewModel customerViewModel = new CustomerViewModel
            {
                CustomerId=result.Id,
                Name=result.Name,
                Gender=result.Gender,
                Details=result.Details,
                RegistrationDate=result.RegistrationDate,
                CitiesList=citylist,
                CityId=result.City.CityId,
                CityName=result.City.CityName

            };
            return View(customerViewModel);
            //Objcustomer.Name = result.Name;
            //Objcustomer.Gender = result.Gender;
            //Objcustomer.Details = result.Details;
            //Objcustomer.RegistrationDate = result.RegistrationDate;
            //Objcustomer.CityId = result.CityId;
            //_context.SaveChanges();
            //return RedirectToAction("Index", "Customer");
        }

        [HttpPost]
        public ActionResult Edit(CustomerViewModel model)
        {

            var Objcustomer = _context.Customers.Where(c => c.Id == model.CustomerId).SingleOrDefault();
            Objcustomer.Name = model.Name;
            Objcustomer.Gender = model.Gender;
            Objcustomer.Details = model.Details;
            Objcustomer.RegistrationDate = Objcustomer.RegistrationDate;
            Objcustomer.CityId = model.CityId;
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");


        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            int ID = Convert.ToInt32(id);
            Customer ObjCustomer = new Customer();
            var result = _context.Customers.Where(c => c.Id == ID).FirstOrDefault();

            return View(result);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            int ID = Convert.ToInt32(id);
            Customer ObjCustomer = new Customer();
            var result = _context.Customers.Where(c => c.Id == ID).FirstOrDefault();
            _context.Customers.Remove(result);
            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }

    }
}