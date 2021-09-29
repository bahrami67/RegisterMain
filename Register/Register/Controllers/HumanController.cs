using Microsoft.AspNetCore.Mvc;
using Register.DataAccessLayer;
using Register.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Register.Controllers
{
    public class HumanController : Controller
    {
        private readonly IRepositoryHuman _repositoryHuman;
        private readonly DB _db;
        public HumanController(IRepositoryHuman repositoryHuman, DB db)
        {
            _repositoryHuman = repositoryHuman;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create(HumanModel human)
        {
            if (human == null)
                return View("Index");

            if (!ModelState.IsValid)
                return View("Index"); 
            
           _repositoryHuman.Create(new Human()
            {
                Name = human.Name,
                Family = human.Family,
                Age = human.Age,
                Gender = human.Gender,
                Phone = human.Phone,
                NationalCode = human.NationalCode,
            });
            return RedirectToAction("Index");
        }
        public IActionResult HumanList()
        {
            var humen = _repositoryHuman.ReadAll().Select(s => new HumanModel()
            {
                Id = s.Id,
                Name = s.Name,
                Family = s.Family,
                Age = s.Age,
                Gender = s.Gender,
                Phone = s.Phone,
                NationalCode = s.NationalCode,
            }).ToList();

            return View(humen);

        }

        public IActionResult Search(string q)
        {
            var human = _repositoryHuman.GetHumanByNC(q);

           var humanModel=human.Select(human=> new HumanModel()
            {
                Id = human.Id,
                Name = human.Name,
                Family = human.Family,
                Age = human.Age,
                Gender = human.Gender,
                Phone = human.Phone,
                NationalCode = human.NationalCode,
            }).ToList();
            return View("HumanList", humanModel);
        }

        public IActionResult HumanInfo(int id)
        {
            var human = _repositoryHuman.GetHumanById(id);

            if (human == null)
                return View("HumanHome");

            var model = new HumanModel()
            {
                Id = human.Id,
                Age = human.Age,
                Family = human.Family,
                Gender = human.Gender,
                Name = human.Name,
                NationalCode = human.NationalCode,
                Phone = human.Phone
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(HumanModel humanModel)
        {

            var human = _repositoryHuman.GetHumanById(humanModel.Id);

            if (human == null)
                RedirectToAction("Index");

            if (!ModelState.IsValid)
                return View("Update");

            human.Name = humanModel.Name;
            human.Family = humanModel.Family;
            human.Age = humanModel.Age;
            human.Gender = humanModel.Gender;
            human.Phone = humanModel.Phone;
            human.NationalCode = humanModel.NationalCode;

            _repositoryHuman.Update(human);

            return RedirectToAction("HumanList");
        }

        public ActionResult HumanDeleteInfo(int id)
        {
            var human = _repositoryHuman.GetHumanById(id);

            var humanModel = new HumanModel()
            {
                Age = human.Age,
                Family = human.Family,
                Name = human.Name,
                Id = human.Id,
                Phone = human.Phone,
                NationalCode = human.NationalCode
            };

            return View(humanModel);

        }

        public ActionResult DeleteHuman(HumanModel human)
        {
            var humanEntity = _repositoryHuman.GetHumanById(human.Id);

            if (human == null)
                return RedirectToAction("HumanList");

            _repositoryHuman.Delete(humanEntity);

            return RedirectToAction("HumanList");
        }
    }
}
