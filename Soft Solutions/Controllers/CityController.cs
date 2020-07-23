using Soft_Solutions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Soft_Solutions.Controllers
{
    public class CityController : Controller
    {
        SoftContext _context = new SoftContext();
        // GET: City
        public ActionResult Index()
        {

            var CitiesList = _context.Cities.ToList();

            return View(CitiesList);
        }

        [HttpGet]
        public ActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Add(City city)
        {
            City ObjCity = new City
            {
                CityName = city.CityName
            };

            _context.Cities.Add(ObjCity);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            int ID = Convert.ToInt32(id);
            City ObjCity = new City();
            var result = _context.Cities.Where(c => c.CityId == ID).FirstOrDefault();
            ObjCity.CityId = result.CityId;
            ObjCity.CityName = result.CityName;
            return View(ObjCity);
        }

        [HttpPost]
        public ActionResult Edit (City model)
        {
            
            var result = _context.Cities.Where(c => c.CityId == model.CityId).FirstOrDefault();
            result.CityName = model.CityName;
           // _context.Cities.Add(result);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            int ID = Convert.ToInt32(id);
            City ObjCity = new City();
            var result = _context.Cities.Where(c => c.CityId == ID).FirstOrDefault();
            ObjCity.CityId = result.CityId;
            ObjCity.CityName = result.CityName;
            return View(ObjCity);
        }
    }
}