using DevPace.Wpf.Api;
using DevPace.Wpf.ViewModels;
using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace DevPace.Wpf.Valildation
{
    public class NameValidationRule : ValidationRule
    {
        public int MaxLength { get; set; } = 320;
        public NameWrapper Wrapper { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                if (((string)value).Length > MaxLength)
                    return new ValidationResult(false, $"Name cannot be longer than {MaxLength} characters");

            }
            catch (Exception ex)
            {
                return new ValidationResult(false, $"Illegal characters or {ex.Message}");
            }

            return ValidationResult.ValidResult;
        }
    }

    public class NameWrapper: DependencyObject
    {
        public static readonly DependencyProperty OriginProperty =
            DependencyProperty.Register("Origin", typeof(string),
                typeof(NameWrapper), new FrameworkPropertyMetadata(string.Empty));

        public string Origin
        {
            get { return (string)GetValue(OriginProperty); }
            set { SetValue(OriginProperty, value); }
        }


    }
}
