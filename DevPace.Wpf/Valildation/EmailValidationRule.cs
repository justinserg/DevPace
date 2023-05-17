using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace DevPace.Wpf.Valildation
{
    public class EmailValidationRule : ValidationRule
    {
        public int MaxLength { get; set; } = 320;
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                if (((string)value).Length > MaxLength)
                    return new ValidationResult(false, $"Email cannot be longer than {MaxLength} characters");

                var pattern = @"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])";
                var isValidEmail = Regex.IsMatch((string)value, pattern);
                if (!isValidEmail)
                {
                    return new ValidationResult(false, $"Enter valid email address");
                }

            }
            catch (Exception ex)
            {
                return new ValidationResult(false, $"Illegal characters or {ex.Message}");
            }

            return ValidationResult.ValidResult;
        }
    }
}
