//using BAL;
//using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace CarInventoryCF.Controllers
{
    public class CarController : Controller
    {
        //ICarRepository repo_car;

        //int pageSize = 3;
        DatabaseContext db = new DatabaseContext();

        //public CarController()
        //{
        //    repo_car = new CarRepository();
        //}

        // GET: Car
        //public ActionResult Index()
        //{
            
        //    List<Car> data = null;
        //    try
        //    {
        //        ////List<Car> data = db.Cars.Select(c => c).ToList();
        //        data = db.Cars.ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error(ex.ToString());
        //    }
        //    return View(data);
        //}


        public ViewResult Index(string SearchBrand, string SearchModel)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger(typeof(CarController));
            
            try
            {
                var cars = from c in db.Cars
                       select c;
                if ((!String.IsNullOrEmpty(SearchBrand)) || (!String.IsNullOrEmpty(SearchModel)))
                {
                    cars = cars.Where(c => c.Brand.ToUpper().Contains(SearchBrand.ToUpper())
                                           || c.Model.ToUpper().Contains(SearchModel.ToUpper()));
                }
                else
                {
                    cars = from c in db.Cars
                           select c;
                }
                return View(cars.ToList());
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
            }

            return View();
            
        }

        //public ActionResult Index(int page = 1, string sort = "carid", string sortDir = "asc", string Search = "")
        //{
        //    log4net.ILog logger = log4net.LogManager.GetLogger(typeof(CarController));

        //    //IEnumerable<Car> data = repo_car.GetAll();
        //     try
        //    {
        //    return View(repo_car.GetCars(pageSize, page, sort.ToLower(), sortDir.ToLower(), Search));
        //    }
        //     catch (Exception ex)
        //     {
        //         logger.Error(ex.ToString());
        //     }
        //     return View();
        //}

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Car mdl)
        {
            db.Cars.Add(mdl);
            //db.Entry(mdl).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Edit(int Id)
        {
            //Car model = db.Cars.Find(Id);
            Car model = db.usp_GetCar(Id);

            return View("Create",model);
        }

        public ActionResult Details(int Id)
        {
            Car model = db.Cars.Find(Id);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Car mdl)
        {
            db.Entry(mdl).State = System.Data.Entity.EntityState.Modified;          
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Delete(int Id)
        {
            Car model = db.Cars.Find(Id);
            if (model != null)
            {
                db.Cars.Remove(model);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
                
        }
    }
}