using GedBooking.Application.Features.Bookings.Commands.CreateBooking;
using GedBooking.Application.Features.Bookings.Commands.DeleteBookingC;
using GedBooking.Application.Features.Bookings.Commands.UpdateBooking;
using GedBooking.Application.Features.Bookings.Queries.GetAllBookings;
using GedBooking.Application.Features.Bookings.Queries.GetBookingById;
using GedBooking.Shared.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GedBooking.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly ISender _sender;

        public BookingController(ISender sender )
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<ActionResult<List<ExamBookingDto>>> GetBookings(CancellationToken cancellationToken)
        {
            var bookings = await _sender.Send(new GetAllBookingsQuery(), cancellationToken);
            return Ok(bookings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExamBookingDto>> GetBookingById(int id, CancellationToken cancellationToken)
        {
            var booking = await _sender.Send(new GetBookingByIdQuery(id), cancellationToken);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);
        }

        [HttpPost]
        public async Task<ActionResult<ExamBookingDto>> CreateBooking([FromBody] ExamBookingDto dto, CancellationToken cancellationToken)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            var created = await _sender.Send(new CreateBookingCommand(dto), cancellationToken);
            return CreatedAtAction(nameof(GetBookingById), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, ExamBookingDto updated)
        {
            var result = await _sender.Send(new UpdateBookingCommand(id, updated));
            if (!result) return NotFound();
            return NoContent();
        }



        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            
            var result = await _sender.Send(new DeleteBookingCommand(id));
            if (!result) return NotFound();
            return NoContent();
        }

    }
}
