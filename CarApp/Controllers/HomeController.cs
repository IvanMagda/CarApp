using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL.Interfaces;
using Domain;
using Model;
using System.Data.Entity;
using CarApp.Models;

namespace CarApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repository;
        public HomeController(IRepository repository)
        {
            _repository = repository;
        }
        public ActionResult Index()
        {
            List<Owner> owners = _repository.Select<Owner>().Include(c => c.Cars).ToList();
            List<Car> cars = _repository.Select<Car>().Include(o => o.Owners).ToList();

            DataListViewModel model = new DataListViewModel
            {
                Cars = cars,
                Owners = owners
            };

            return View(model);
        }

        public ActionResult Cars()
        {
            List<Car> cars = _repository.Select<Car>().Include(c => c.Owners).ToList();
            ViewBag.Cars = cars;
            return View();
        }

        public ActionResult Owners()
        {
            List<Owner> owners = _repository.Select<Owner>().Include(c => c.Cars).ToList();
            ViewBag.Owners = owners;
            return View();
        }

        public ViewResult CreateCar()
        {
            Car car = new Car();
            car.Owners = new List<Owner>();
            return View("EditCar", new CarEditViewModel() { Car = car, Owners = _repository.Select<Owner>().Include(c => c.Cars).ToList() });
        }

        public ViewResult EditCar(int id)
        {
            Car car = _repository.Select<Car>().Include(c => c.Owners).FirstOrDefault(c => c.Id == id);
            List<Owner> owners = _repository.Select<Owner>().ToList();
            CarEditViewModel model = new CarEditViewModel
            {
                Car = car,
                Owners = owners
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult EditCar(CarEditViewModel model)
        {
            if(model.Car.Id != 0) { _repository.Update(model.Car); }
            Car car = model.Car.Id == 0 ? model.Car : _repository.Select<Car>().Include(c => c.Owners).FirstOrDefault(c => c.Id == model.Car.Id);

            if (Request.Form["ownersSelect"] != null)
            {
                int[] owners = Request.Form["ownersSelect"].Split(',').Select(n => Convert.ToInt32(n)).ToArray();
                List<Owner> ownersList = _repository.Select<Owner>().Where(o => owners.Contains(o.Id)).ToList();
                car.Owners.Clear();
                ownersList.ForEach(o => car.Owners.Add(o));
            }

            if (ModelState.IsValid)
            {
                if (model.Car.Id == 0){
                    _repository.Insert(car);
                }else{
                    _repository.Update(car);
                }
                return RedirectToAction("Cars");
            }
            return View(new CarEditViewModel() { Car = car, Owners = _repository.Select<Owner>().Include(c => c.Cars).ToList() });
        }

        public ViewResult CreateOwner()
        {
            Owner owner = new Owner();
            owner.Cars = new List<Car>();
            return View("EditOwner", new OwnerEditViewModel() { Owner = owner, Cars = _repository.Select<Car>().Include(c => c.Owners).ToList() });
        }

        public ViewResult EditOwner(int id)
        {
            Owner owner = _repository.Select<Owner>().Include(c => c.Cars).FirstOrDefault(c => c.Id == id);
            List<Car> cars = _repository.Select<Car>().ToList();
            OwnerEditViewModel model = new OwnerEditViewModel
            {
                Owner = owner,
                Cars = cars
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult EditOwner(OwnerEditViewModel model)
        {
            if (model.Owner.Id != 0) { _repository.Update(model.Owner); }
            Owner owner = model.Owner.Id == 0 ? model.Owner : _repository.Select<Owner>().Include(c => c.Cars).FirstOrDefault(c => c.Id == model.Owner.Id);

            if (Request.Form["carsSelect"] != null)
            {
                int[] cars = Request.Form["carsSelect"].Split(',').Select(n => Convert.ToInt32(n)).ToArray();
                List<Car> carsList = _repository.Select<Car>().Where(o => cars.Contains(o.Id)).ToList();
                owner.Cars.Clear();
                carsList.ForEach(c => owner.Cars.Add(c));
            }

            if (ModelState.IsValid)
            {
                if (model.Owner.Id == 0)
                {
                    _repository.Insert(owner);
                }
                else
                {
                    _repository.Update(owner);
                }
                return RedirectToAction("Owners");
            }
            return View(new OwnerEditViewModel() { Owner = owner, Cars = _repository.Select<Car>().Include(c => c.Owners).ToList() });
        }

        public ActionResult DeleteCar(int id)
        {
            Car car = _repository.Select<Car>().FirstOrDefault(c => c.Id == id);
            _repository.Delete(car);
            return RedirectToAction("Cars");
        }

        public ActionResult DeleteOwner(int id)
        {
            Owner owner = _repository.Select<Owner>().FirstOrDefault(c => c.Id == id);
            _repository.Delete(owner);
            return RedirectToAction("Owners");
        }
    }
}