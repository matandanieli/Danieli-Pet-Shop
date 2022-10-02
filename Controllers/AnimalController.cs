using DanieliPetShop.Models;
using DanieliPetShop.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DanieliPetShop.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IRepository _repository;
        public AnimalController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index(int id) //show all the details about this animal.
        {
            var animal = _repository.GetAnimals().Single(a => a.AnimalId == id);
            return View(animal);
        }

        public IActionResult ShowReceipt(int id) //show the reciept about this animal after purchase.
        {
            var animal = _repository.GetAnimals().Single(a => a.AnimalId == id);
            ViewBag.AnimalName = animal.Name;
            _repository.DeleteAnimal(id);
            return View(animal);
        }
        public IActionResult AddReview(int id, string comment, string writer)
        {
            if (ModelState.IsValid)
            {
                var animalFound = _repository.AddReview(id, comment, writer);
                return View("Index", animalFound);
            }
            else return View();
        }
    }
}
