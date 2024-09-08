
using System;
using System.ComponentModel.DataAnnotations;

namespace Exterminator.Models.Attributes
{
    // Custom validation attribute for the GhostbusterInputModel
    public class ExpertizeAttribute : ValidationAttribute
    {
        private string[] _allowedExpertize = ["Ghost catcher", "Ghoul strangler", "Monster encager", "Zombie exploder"];

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Must provide some Expertize value");
            }

            var expertize = value.ToString();

            if (!Array.Exists(_allowedExpertize, e => e.Equals(expertize, StringComparison.OrdinalIgnoreCase)))
            {
                return new ValidationResult("Value must be one of the following: “Ghost catcher”, “Ghoul strangler”, “Monster encager” or “Zombie exploder”");
            }

            return ValidationResult.Success;

        }
    }
}