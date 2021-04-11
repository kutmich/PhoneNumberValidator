using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneNumberValidator.Application.Response
{
        public abstract class BaseResponse
        {
            public string Message { get; private set; }

            public BaseResponse(string message)
            {
                Message = message;
            }
    }
}
