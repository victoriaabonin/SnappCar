using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SnappetGarage.Interfaces.Application;
using System;
using System.Threading.Tasks;

namespace SnappetGarage.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SnappetCarsController : ControllerBase
    {
        private readonly ISnappetCarsService _snappetCarsService;

        public SnappetCarsController(ISnappetCarsService snappetCarsService)
        {
            _snappetCarsService = snappetCarsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPrice(int carId)
        {
            try
            {
                if (carId <= 0 )
                {
                    return BadRequest("carId must be above 0");
                }

                return Ok(await _snappetCarsService.GetSnappetCar(carId));
            }
            catch (Exception e)
            {
                // log
                return StatusCode(StatusCodes.Status500InternalServerError);
            }            
        }
    }
}
