using DanieliPetShop.Models;

namespace DanieliPetShop.Repositories
{
    public interface IRepository //an interface to implement in my repository 
    {
        IEnumerable<Animal> GetAnimals();
        void AddAnimal(Animal animal);
        void EditAnimal(int id, Animal animal);
        void DeleteAnimal(int id);
        List<Animal> GetTopReviewed();
        List<Animal> GetAnimalsByCategory(string category);
        Animal AddReview(int id, string comment, string writer);
    }
}
