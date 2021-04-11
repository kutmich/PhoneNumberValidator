using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneNumberValidator.Application.Response
{
    public class PhoneNumberValidationResponse : BaseResponse
    {
        public string phoneNumber { get; private set; }
        public bool toCall { get; private set; }

        public PhoneNumberValidationResponse(string number, bool isAvalible, string message) : base(message) 
        {
            phoneNumber = number;
            toCall = isAvalible;
        }
    }
}
