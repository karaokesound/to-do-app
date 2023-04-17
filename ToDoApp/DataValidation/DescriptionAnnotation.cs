using System.Globalization;
using System.Windows.Controls;

namespace ToDoApp
{
    public class DescriptionAnnotation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string charString = value as string;

            if (charString.Length == 0)
            {
                return new ValidationResult(false, $"Text your task's description \n" +
                    $"Use # - hashtag instead to assign the task \n" +
                    $"to an ealier created category (in categories panel");
            }
            return new ValidationResult(true, null);
        }
    }
}
