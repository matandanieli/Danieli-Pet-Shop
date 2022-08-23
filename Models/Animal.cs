using System.ComponentModel.DataAnnotations;
using DanieliPetShop.Validators;

namespace DanieliPetShop.Models
{
    public class Animal //all the animal props with validation attributes. 
    {
        [Required(ErrorMessage = "Please enter the animal id.")]
        [Display(Name = "Id:")]
        public int AnimalId { get; set; }
        [Required(ErrorMessage = "Please enter the animal name.")]
        [AllLettersValidation(ErrorMessage = "Only letters allowed.")]
        [Display(Name = "Name:")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please enter the animal age.")]
        [Display(Name = "Age:")]
        [Range(0,300)]
        public int? Age { get; set; }
        [Required(ErrorMessage = "Please enter the animal photo.")]
        [Display(Name = "Photo:")]
        public string? Picture { get; set; }
        [Required(ErrorMessage = "Please enter the animal category.")]
        [Display(Name = "Category:")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Please enter the animal price.")]
        [Display(Name = "Price:")]
        public int Price { get; set; }
        [Display(Name = "Description:")]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }
        public ICollection<Review>? Reviews { get; set; }
        public Category? Category { get; set; }
    }
}
