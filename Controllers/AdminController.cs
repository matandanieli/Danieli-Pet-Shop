using DanieliPetShop.Models;
using DanieliPetShop.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DanieliPetShop.Controllers
{
    public class AdminController : Controller
    {
        private readonly IRepository _repository;
        public AdminController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index() //show all the shop list
        {
            var animals = _repository.GetAnimals();
            return View(animals);
        }

        public IActionResult EditPage(int id) // open an edit page to chane the animal props.
        {
            var animal = _repository.GetAnimals().Single(a => a.AnimalId == id);
            ViewBag.Name = animal.Name;
            return View(animal);
        }

        public IActionResult Edit(int id, Animal animal) //edit the props after click the edit button in edit page.
        {
            _repository.EditAnimal(id, animal);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) //delete the chosen animal from data base
        {
            _repository.DeleteAnimal(id);
            return RedirectToAction("Index");
        }
    }
}
