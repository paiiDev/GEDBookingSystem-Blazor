using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GedBooking.Shared.DTOs
{
    public class ExamBookingDto
    {
        public int Id { get; set; }

    [Required(ErrorMessage = "ကျောင်းသားအမည် ထည့်သွင်းရန် လိုအပ်ပါသည်။")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "အမည်သည် အနည်းဆုံး ၃ လုံး ရှိရပါမည်။")]
    public string StudentName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email လိပ်စာ ထည့်သွင်းရန် လိုအပ်ပါသည်။")]
    [EmailAddress(ErrorMessage = "Email ပုံစံ မှန်ကန်မှု မရှိပါ။")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "ဖြေဆိုမည့် ဘာသာရပ် ရွေးချယ်ပေးပါ။")]
    public string Subject { get; set; } = "Mathematical Reasoning"; // RLA, Math, Science, Social Studies

    [Required(ErrorMessage = "ဖြေဆိုမည့်ရက် ရွေးချယ်ပေးပါ။")]
    public DateTime ExamDate { get; set; } = DateTime.Today.AddDays(7);

    [Range(50, 200, ErrorMessage = "စာမေးပွဲကြေးသည် $50 နှင့် $200 ကြား ဖြစ်ရပါမည်။")]
    public decimal ExamFee { get; set; } = 80m;

    public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected
    }
}
