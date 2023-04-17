using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Windows.Controls;

namespace ToDoApp
{
    public class MinimumCharacterRule : ValidationRule
    {
        public int MinimumCharacters { get; set; }
        public int MaximumCharacters { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string charString = value as string;

            if (charString.Length < MinimumCharacters)
            {
                return new ValidationResult(false, $"_min. {MinimumCharacters} characters");
            }
            else if (charString.Length > MaximumCharacters)
            {
                return new ValidationResult(false, $"_max. {MaximumCharacters} characters");
            }
                return new ValidationResult(true, null);
            
        }
    }
}
