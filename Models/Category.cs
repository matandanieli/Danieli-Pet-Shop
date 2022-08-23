namespace DanieliPetShop.Models
{
    public class Category //all the category props
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public ICollection<Animal>? Animals { get; set; }
    }
}
