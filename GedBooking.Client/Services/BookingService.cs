using GedBooking.Shared.DTOs;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace GedBooking.Client.Services
{
    public class BookingService : IBookingService
    {
        private readonly HttpClient _httpClient;

        public BookingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ExamBookingDto>> GetBookingsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ExamBookingDto>>("api/booking") ?? new List<ExamBookingDto>();
        }

        public async Task<ExamBookingDto?> GetBookingByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ExamBookingDto>($"api/bookings/{id}");
        }

        public async Task<bool> CreateBookingAsync(ExamBookingDto booking)
        {
            var response = await _httpClient.PostAsJsonAsync("api/bookings", booking);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateBookingAsync(int id, ExamBookingDto booking)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/bookings/{id}", booking);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteBookingAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/bookings/{id}");
            return response.IsSuccessStatusCode;
        }

    }
}
