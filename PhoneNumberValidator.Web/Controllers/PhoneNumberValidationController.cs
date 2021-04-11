using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhoneNumberValidator.Application.Response;
using PhoneNumberValidator.Application.Services.Interfaces;
using PhoneNumberValidator.Application.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneNumberValidator.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneNumberValidationController : ControllerBase
    {
        private readonly ILogger<PhoneNumberValidationController> _logger;
        IValidatePhoneNumberService _service;
        public PhoneNumberValidationController(IValidatePhoneNumberService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<PhoneNumberValidationResponse> ValidateAsync(String phoneNumber)
        {
            try
            {
                
                if(!Helper.CheckFormat(phoneNumber))
                    return new PhoneNumberValidationResponse(null, false, "Wrong format number.");

                phoneNumber = Helper.ExtractNumbers(phoneNumber);// in case if number (xxx)xxxxxx
                return await _service.ValidateAsync(phoneNumber);

            }
            catch (Exception ex) 
            {
                _logger.LogInformation(ex.InnerException.ToString());  //write to file or database
                return new PhoneNumberValidationResponse(null, false, "An error occurred, contact administrator.");
            }
        }
    }
}
