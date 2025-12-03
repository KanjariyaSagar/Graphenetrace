using System;

namespace WebApplication2.Models
{
    public class MetricReading
    {
        public int Id { get; set; }

        // e.g. 2025-11-16 (one row per day)
        public DateTime Date { get; set; }

        // Daily summary for that day
        public decimal AvgPpi { get; set; }
        public decimal AvgContactAreaPct { get; set; }
        public int UploadCount { get; set; }
    }
}
