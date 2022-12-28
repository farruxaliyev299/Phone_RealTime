using MobilePhone.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.Helpers.Validations
{
    public static class PhoneNumberValidation
    {
        public static bool IsValidWithoutAnything(string number, List<string> providers)
        {
            return number.Length == 9 &&
                   providers.Any(pr => number.StartsWith(pr.Substring(0, 2))) &&
                   number.All(num => Char.IsDigit(num));
        }

        public static bool IsValidWithCountryCode(string number, List<string> providers)
        {
            return number.Length == 13 &&
                   number.StartsWith("+994") &&
                   providers.Any(pr => number.Substring(4, 2).StartsWith(pr.Substring(0, 2))) &&
                   number.Substring(1).All(num => Char.IsDigit(num));
        }
        
        public static bool IsValidWithZeroAtStart(string number, List<string> providers)
        {
            return number.Length == 10 &&
                   providers.Any(pr => number.StartsWith("0" + pr)) &&
                   number.All(num => Char.IsDigit(num));
        }

        //Combines all phone number validations in case you don't need them in separate
        public static bool IsValid(string number, List<string> providers)
        {
            if (!IsValidWithoutAnything(number, providers)) return false;
            if (!IsValidWithCountryCode(number, providers)) return false;
            if (!IsValidWithZeroAtStart(number, providers)) return false;

            return true;
        }
        
    }
}
