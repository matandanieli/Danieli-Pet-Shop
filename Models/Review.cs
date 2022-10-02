namespace DanieliPetShop.Models
{
    public class Review //all the review props
    {
        public int ReviewId { get; set; }
        public int AnimalId { get; set; }
        public string? Text { get; set; } // attribute
        public Animal? Animal { get; set; }
        public string? Writer { get; set; }
    }
}
