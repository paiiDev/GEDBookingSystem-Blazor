using GedBooking.Application.Features.Bookings.Queries.GetAllBookings;
using GedBooking.Shared.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GedBooking.Api.Controllers
{
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

        //[HttpGet("{id}")]
        //public async Task<ActionResult<ExamBookingDto>> GetBookingById(int id)
        //{
        //    var booking = await _sender.Send(new GetBookingByIdQuery(id), cancellationToken);
        //    if (booking == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(booking);
        //}

        //[HttpPost]
        //public async Task<ActionResult<ExamBookingDto>> CreateBooking([FromBody] ExamBookingDto dto)
        //{
        //    if(dto == null)
        //    {
        //        return BadRequest();
        //    }
        //    var created = await _repo.CreateAsync(dto);
        //    return CreatedAtAction(nameof(GetBookingById), new { id = created.Id }, created);
        //}

        //[HttpPut("{id:int}")]
        //public async Task<IActionResult> Update(int id, ExamBookingDto updated)
        //{
        //    var esisting = await _repo.GetByIdAsync(id);
        //    if(esisting == null) return NotFound();
        //    var result = await _repo.UpdateAsync(id, updated);
        //    if (!result) return NotFound();
        //    return NoContent();
        //}

           

        //[HttpDelete("{id:int}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var existing = await _repo.GetByIdAsync(id);
        //    if(existing == null) return NotFound();
        //    var result = await _repo.DeleteAsync(id);
        //    if (!result) return NotFound();
        //    return NoContent();
        //}
            
    }
}
