using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Booking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingContoller : ControllerBase
    {

        public BookingContoller()
        {
        }

        [HttpGet]
        public async Task<IActionResult> BookSnappetCar()
        {
            return Ok();
        }
    }
}
