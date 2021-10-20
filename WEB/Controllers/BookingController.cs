using BAL.Enum;
using BAL.Model;
using BAL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpPost]
        [Route("BookResource")]
        public IActionResult BookResource(BookingModel booking)
        {
            var response = _bookingService.BookResource(booking);
            if (response.Status == ResponseStatus.Success)
            {
                return StatusCode(StatusCodes.Status200OK, _bookingService.BookResource(booking));
            }
            else
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity, _bookingService.BookResource(booking));
            }
        }
    }
}
