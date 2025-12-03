using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Alert
    {
        [Key]
        public long AlertID { get; set; }          // PK for Alert – can stay long

        public int PatientID { get; set; }

        // 👇 MUST MATCH SensorFrame.DataID (which is int)
        public int? DataID { get; set; }

        [Required]
        public string Severity { get; set; } = default!;   // "High" / "Medium" / "Low"

        [Required]
        public string Message { get; set; } = default!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("PatientID")]
        public User Patient { get; set; } = default!;

        [ForeignKey("DataID")]
        public SensorFrame? Data { get; set; }
    }
}
