using GedBooking.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GedBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private static readonly List<ExamBookingDto> _bookings = new List<ExamBookingDto>
        {
        new ExamBookingDto { Id = 1, StudentName = "Aung Kyaw", Email = "aung@gmail.com", Subject = "Mathematical Reasoning", ExamDate = DateTime.Today.AddDays(5), ExamFee = 80, Status = "Approved" },
        new ExamBookingDto { Id = 2, StudentName = "Su Su", Email = "susu@gmail.com", Subject = "Science", ExamDate = DateTime.Today.AddDays(10), ExamFee = 80, Status = "Pending" },
        new ExamBookingDto { Id = 3, StudentName = "Min Khant", Email = "min@gmail.com", Subject = "Social Studies", ExamDate = DateTime.Today.AddDays(12), ExamFee = 80, Status = "Rejected" }
        };

        [HttpGet]
        public ActionResult<List<ExamBookingDto>> GetBookings()
        {
            return Ok(_bookings);
        }

        [HttpGet("{id}")]
        public ActionResult<ExamBookingDto> GetBookingById(int id)
        {
            var booking = _bookings.FirstOrDefault(b => b.Id == id);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);
        }

        [HttpPost]
        public ActionResult<ExamBookingDto> CreateBooking([FromBody] ExamBookingDto dto)
        {
            dto.Id = _bookings.Any() ? _bookings.Max(b => b.Id) + 1 : 1;
            _bookings.Add(dto);
            return CreatedAtAction(nameof(GetBookingById), new { id = dto.Id }, dto);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, ExamBookingDto updated)
        {
            var existing = _bookings.FirstOrDefault(b => b.Id == id);
            if (existing is null) return NotFound();

            existing.StudentName = updated.StudentName;
            existing.Email = updated.Email;
            existing.Subject = updated.Email;
            existing.Subject = updated.Subject;
            existing.ExamDate = updated.ExamDate;
            existing.ExamFee = updated.ExamFee;
            existing.Status = updated.Status;

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var existing = _bookings.FirstOrDefault(b => b.Id == id);
            if (existing is null) return NotFound();

            _bookings.Remove(existing);
            return NoContent();
        }
    }
}
