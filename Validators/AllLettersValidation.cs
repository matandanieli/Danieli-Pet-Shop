using System.ComponentModel.DataAnnotations;

namespace DanieliPetShop.Validators
{
    public class AllLettersValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            return (value != null) && ((string)value).All(char.IsLetter);
        }
    }
}
