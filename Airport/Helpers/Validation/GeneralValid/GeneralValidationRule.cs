using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Airport.validation.GeneralValid
{
    public static class GeneralValidationRule
    {
        public static bool BasicValidate(string value)
        {
            if (value != "") return true; else return false;
        }

        public static bool ValidateFlightNumber(string value)
        {
            string reg = @"^\w{2,3}-\d{3}$";
            if(Regex.IsMatch(value, reg)) return true; else return false;
        }

        public static bool PasswordValidate(string value)
        {
            string reg = @"^\d{4}-\d{6}";
            if(Regex.IsMatch(value, reg)) return true; else return false;
        }

        public static bool DigitValidate(string value)
        {
            if(int.TryParse(value, out int result)) return true; else return false;
        }
    }
}
