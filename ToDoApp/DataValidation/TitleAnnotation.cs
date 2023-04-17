using System.Globalization;
using System.Windows.Controls;

namespace ToDoApp
{
    public class TitleAnnotation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string charString = value as string;

            if (charString.Length == 0)
            {
                return new ValidationResult(false, $"Text your task's title");
            }
            return new ValidationResult(true, null);
        }
    }
}
