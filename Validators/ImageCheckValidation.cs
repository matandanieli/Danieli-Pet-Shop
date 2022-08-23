using System.ComponentModel.DataAnnotations;

namespace DanieliPetShop.Validators
{
	public class ImageCheckValidation : ValidationAttribute
	{
        //public override bool IsValid(object? value, string name)
        //{
        //    return name.ToLower().EndsWith((".png", ".jpg", ".jpeg", ".tiff", ".bmp", ".gif"));
        //}
    }
}
