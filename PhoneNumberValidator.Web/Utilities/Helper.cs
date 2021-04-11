using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PhoneNumberValidator.Application.Utilities
{
    public class Helper
    {
        public static bool CheckFormat(string phoneNumber)
        {
            Regex rg = new Regex("^[0-9.()-]{10,20}$");
            return rg.IsMatch(phoneNumber);
        }

        public static string ExtractNumbers(string phoneNumber)
        {
            string result = ""; 
            var matches = Regex.Matches(phoneNumber, @"\d+");
            foreach (var match in matches)
            {
                result += match;
            }
            return result;
        }
    }
}
