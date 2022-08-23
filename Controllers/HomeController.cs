using DanieliPetShop.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DanieliPetShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repository;
        public HomeController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index() => View(_repository.GetTopReviewed()); //show 2 animals who has the most reviews. 
    }
}
