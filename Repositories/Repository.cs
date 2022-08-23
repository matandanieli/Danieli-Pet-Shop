using DanieliPetShop.Data;
using DanieliPetShop.Models;
using Microsoft.EntityFrameworkCore;

namespace DanieliPetShop.Repositories
{
    public class Repository : IRepository
    {
        private readonly ShopContext _context;
        public Repository(ShopContext context) => _context = context;

        public void DeleteAnimal(int id) //delete an animal from the data base
        {
            var deletedAnimal = FindAnimalById(id);
            _context.Animals!.Remove(deletedAnimal);
            _context.SaveChanges();
        }

        public void EditAnimal(int id, Animal animal) //edit an animal props
        {
            var animalInDb = FindAnimalById(id);
            animalInDb.Name = animal.Name;
            animalInDb.Age = animal.Age;
            animalInDb.Picture = "/images/Animals/" + animal.Picture;
            animalInDb.Description = animal.Description;
            animalInDb.CategoryId = animal.CategoryId;
            animalInDb.Price = animal.Price;
            _context.SaveChanges();
        }

        public List<Animal> GetTopReviewed() //get the top 2 most revied animals
        {
            var animals = _context.Animals!.Include(a => a.Reviews);
            var top2animals = animals.OrderByDescending(r => r.Reviews!.Count).Take(2).ToList();
            return top2animals;
        }

        public List<Animal> GetAnimalsByCategory(string category) //get all the animals the this category
        {
            var animals = _context.Animals!.Include(c => c.Category).Where(c => c.Category!.Name == category);
            if (category == "Show all" || category == null) return _context.Animals!.ToList();
            else return animals.ToList();
        }

        public void AddAnimal(Animal animal) // add animal to the data base
        {
            _context.Animals!.Add(animal);
            _context.SaveChanges();
        }

        public IEnumerable<Animal> GetAnimals() => _context.Animals!; //get all the animals the in data base
        public IEnumerable<Category> GetCategories() => _context.Categories!; //get all the categories in the data base

        public Animal AddReview(int id, string comment)
        {
            var animalFound = FindAnimalById(id);

            Review review = new() { Text = comment, AnimalId = id };
            animalFound.Reviews!.Add(review);

            _context.SaveChanges();
            return animalFound;
        }

        public Animal FindAnimalById(int id)
        {
            var categories = _context.Animals!.Include(c => c.Category).ThenInclude(c => c!.Animals!).ThenInclude(c => c.Reviews);
            var animal = categories!.Single(m => m.AnimalId == id);
            return animal;
        }
    }
}
