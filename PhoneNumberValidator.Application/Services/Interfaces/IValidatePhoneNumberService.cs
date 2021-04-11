using PhoneNumberValidator.Application.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumberValidator.Application.Services.Interfaces
{
    public interface IValidatePhoneNumberService
    {
        Task<PhoneNumberValidationResponse> ValidateAsync(string number);
        Task<List<PhoneNumberValidationResponse>> ValidateAsync(List<string> number);
    }
}
