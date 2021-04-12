using PhoneNumberValidator.Application.Response;
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

        public static bool CheckFormat(List<string> phoneNumbers)
        {
            foreach (var phoneNumber in phoneNumbers)
            {
                if (!CheckFormat(phoneNumber)) return false; // if phoneNumber in bad format
            }
            return true; // all in valid format
        }

        public static List<string> FilterByCorruptFormat(List<string> phoneNumbers)
        {
            List<string> result = new List<string>(); 

            foreach (var phoneNumber in phoneNumbers)
            {
                if (!CheckFormat(phoneNumber)) 
                    result.Add(phoneNumber); // if phoneNumber in bad format
            }
            return result; // bad formats
        }

        public static List<PhoneNumberValidationResponse> BadFormatResponse(List<string> phoneNumbers)
        {
            List<PhoneNumberValidationResponse> result = new List<PhoneNumberValidationResponse>();

            foreach (var phoneNumber in phoneNumbers)
            {
                result.Add(new PhoneNumberValidationResponse(phoneNumber, false, "Bad number format"));
            }
            return result; // bad formats
        }

        public static string FilterNonNumeric(string phoneNumber)
        {
            string result = String.Empty; 

            var matches = Regex.Matches(phoneNumber, @"\d+");

            foreach (var match in matches)
            {
                result += match;
            }
            return result;
        }

        public static List<string> FilterNonNumeric(List<string> phoneNumbers)
        {
            List<string> result = new List<string>();

            foreach (var phoneNumber in phoneNumbers)
            {
                result.Add(FilterNonNumeric(phoneNumber));
            }
            return result;
        }


    }
}
