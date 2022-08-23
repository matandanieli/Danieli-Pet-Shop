using DanieliPetShop.Models;
using DanieliPetShop.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DanieliPetShop.Controllers
{
    public class InsertController : Controller
    {
        private readonly IRepository _repository;
        public InsertController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index() //show an insert page the fill the animal props
        {
            return View();
        }

        public IActionResult Add(Animal animal) //add the animal to the data base
        {
            if (ModelState.IsValid)
            {
                _repository.AddAnimal(animal);
                return RedirectToAction("index", "admin");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
