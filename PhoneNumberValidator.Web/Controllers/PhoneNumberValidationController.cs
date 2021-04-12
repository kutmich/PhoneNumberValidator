using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhoneNumberValidator.Application.Response;
using PhoneNumberValidator.Application.Services.Interfaces;
using PhoneNumberValidator.Application.Utilities;
using Prometheus;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneNumberValidator.Web.Controllers
{

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
        [Route("CheckNumberValidity")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ValidateAsync(string phoneNumber)
        {
            try
            {
                if(!Helper.CheckFormat(phoneNumber))
                     return Ok(new PhoneNumberValidationResponse(null, false, "Wrong format number."));

                phoneNumber = Helper.FilterNonNumeric(phoneNumber);// in case if number (xxx)xxxxxx, +1xxxxxxxxx
                return Ok(await _service.ValidateAsync(phoneNumber));

            }
            catch (Exception ex) 
            {
                _logger.LogInformation(ex.InnerException.ToString());  //write to file or database
                return BadRequest("An error occurred, contact administrator.");
            }
        }

        [HttpPost]
        [Route("GetValidNumbers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ValidateManyAsync([FromBody] List<string> phoneNumbers)
        {
            try
            {
                var badFormatNumbers = Helper.FilterByCorruptFormat(phoneNumbers);

                if (badFormatNumbers.Count > 0) 
                    return Ok(Helper.BadFormatResponse(phoneNumbers));

                phoneNumbers = Helper.FilterNonNumeric(phoneNumbers);// in case if number (xxx)xxxxxx, +1xxxxxxxxx

                return Ok(await _service.ValidateAsync(phoneNumbers));

                

            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.InnerException.ToString());  //write to file or database
                return BadRequest("An error occurred, contact administrator.");
            }
        }
    }
}
