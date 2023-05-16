using System;
using System.Globalization;
using System.Windows.Controls;

namespace DevPace.Wpf.Valildation
{
    internal class LengthValidationRule : ValidationRule
    {
        public int MaxLength { get; set; } = 50;
        public string Name { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                if (((string)value).Length > MaxLength)
                    return new ValidationResult(false, $"{Name} cannot be longer than {MaxLength} characters");
            }
            catch(Exception ex)
            {
                return new ValidationResult(false, $"Illegal characters or {ex.Message}");
            }

            return ValidationResult.ValidResult;
        }
    }
}
