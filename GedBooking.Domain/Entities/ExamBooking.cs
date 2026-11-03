using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GedBooking.Domain.Entities
{
    public class ExamBooking
    {
        public int Id { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public DateTime ExamDate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ExamFee { get; set; }
        public string Status { get; set; } = "Pending";

        // Database အတွက် သီးသန့် လိုအပ်သော Audit Fields များ
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
