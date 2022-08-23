using DanieliPetShop.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DanieliPetShop.Controllers
{
    public class ShopTableController : Controller
    {
        private readonly IRepository _repository;
        public ShopTableController(IRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index() //show all the shop list
        {
            return View();
        }

        public IActionResult Filter(string category) //filter the shop list according the user choose.
        {
            if (category == "Show all" || category == null) return View("Index");
            return View(_repository.GetAnimalsByCategory(category));
        }
    }
}
