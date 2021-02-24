using Models;
using Actions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly BookingAction _bookingAction;

        public BookingsController(BookingAction bookingAction)
        {
            _bookingAction = bookingAction;
        }

        [HttpGet]
        public ActionResult<List<Booking>> Get() =>
            _bookingAction.Get();

        [HttpGet("{id:length(24)}", Name = "GetBooking")]
        public ActionResult<Booking> Get(string id)
        {
            var booking = _bookingAction.Get(id);

            if (booking == null)
            {
                return NotFound();
            }

            return booking;
        }

        [HttpPost]
        public ActionResult<Booking> Create(Booking booking)
        {
            _bookingAction.Create(booking);

            return CreatedAtRoute("GetBooking", new { id = booking.Id.ToString() }, booking);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Booking newBooking)
        {
            var booking = _bookingAction.Get(id);

            if (booking == null)
            {
                return NotFound();
            }

            newBooking.Id = id;

            _bookingAction.Update(id, newBooking);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var booking = _bookingAction.Get(id);

            if (booking == null)
            {
                return NotFound();
            }

            _bookingAction.Remove(id);

            return NoContent();
        }
        
    }
}