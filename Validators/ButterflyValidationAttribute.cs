using ButterfliesShop.Models;
using ButterfliesShop.Services;
using System.ComponentModel.DataAnnotations;

namespace ButterfliesShop.Validators
{
    public class ButterflyValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var butterfly = validationContext.ObjectInstance as Butterfly;
            var butterfliesQuantityService = validationContext.GetService(typeof(IButterfliesQuantityService)) as IButterfliesQuantityService;

            if (butterfly.ButterflyFamily == null) return new ValidationResult("You need to select a family.");
            var currentButterfliesFamilyQuantity = butterfliesQuantityService.GetButterflyFamilyQuantity(butterfly.ButterflyFamily.Value).Value;

            if (butterfly.Quantity == null) return new ValidationResult("You need to enter a quantity.");
            var butterflyFamilyQuantity = currentButterfliesFamilyQuantity + butterfly.Quantity.Value;

            if (butterflyFamilyQuantity < 0 || butterflyFamilyQuantity > 50) 
                return new ValidationResult($"Maximum is 50. There is {currentButterfliesFamilyQuantity} in this family.");
            
            return ValidationResult.Success;
        }
    }
}
