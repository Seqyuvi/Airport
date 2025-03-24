using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.validation.GeneralValid
{
    public static class GeneralValidation
    {
        public static bool IsNullOrEmpty(this string value) => string.IsNullOrEmpty(value);

        public static bool ContainsDigits(this string value) => value.Any(char.IsDigit);

        public static bool ContainsLetter(this string value) => value.Any(char.IsLetter);
    }
}
