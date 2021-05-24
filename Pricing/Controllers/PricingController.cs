using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pricing.Application.Interfaces;
using Pricing.Models.RequestModels;
using System;
using System.Threading.Tasks;

namespace Pricing.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PricingController : ControllerBase
    {
        private readonly IPricingService _pricingService;

        public PricingController(IPricingService pricingService)
        {
            _pricingService = pricingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPrice(GetPriceRequestModel getPriceRequestModel)
        {
            try
            {
                if (getPriceRequestModel.CarId == 0 ||
                getPriceRequestModel.StartDate.Date < DateTime.Now.Date ||
                getPriceRequestModel.EndDate.Date < getPriceRequestModel.StartDate.Date)
                {
                    return BadRequest("Invalid arguments");
                }

                return Ok(await _pricingService.GetPrice(getPriceRequestModel));
            }
            catch (Exception e)
            {
                // log
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
