using PhoneNumberValidator.Application.Response;
using PhoneNumberValidator.Application.Services.Interfaces;
using PhoneNumberValidator.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumberValidator.Application.Services.Contracts
{
    public class ValidatePhoneNumberService : IValidatePhoneNumberService
    {
        private readonly IInternalDoNotCallRepository _internalRepo;
        private readonly INationalDoNotCallRepository _nationalRepo;
        public ValidatePhoneNumberService(IInternalDoNotCallRepository internalRepo, INationalDoNotCallRepository nationalRepo)
        {
            _internalRepo = internalRepo;
            _nationalRepo = nationalRepo;
        }

        public async Task<PhoneNumberValidationResponse> ValidateAsync(string number)
        {
            try
            {
                var existsInInternalList = await _internalRepo.ExistsAsync(number);
                if (existsInInternalList) 
                    return new PhoneNumberValidationResponse(number, false, "Number is not valide for calling");

                var existsInNationalList = await _nationalRepo.ExistsAsync(number);
                if (!existsInNationalList)
                    return new PhoneNumberValidationResponse(number, true, "Number is valide for calling");

                var existsInNationalListAndMember = await _nationalRepo.IsMemberAndNationalDoNotCallAsync(number);  
                if(existsInNationalListAndMember)
                    return new PhoneNumberValidationResponse(number, true, "Number is valide for calling");

                return new PhoneNumberValidationResponse(number, false, "Number is not valide for calling");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<PhoneNumberValidationResponse>> ValidateAsync(List<string> numbers)
        {
            try
            {
                List<PhoneNumberValidationResponse> result = new List<PhoneNumberValidationResponse>();
                foreach (var number in numbers)
                {
                    result.Add(await ValidateAsync(number));
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
