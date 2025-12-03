using System;
using System.Collections.Generic;

namespace WebApplication2.Models.ViewModels
{
    public class ClinicianMetricsVM
    {
        // Top KPI cards
        public int TotalFrames { get; set; }
        public int TodaysUploads { get; set; }
        public int DistinctPatients { get; set; }
        public DateTime? LastUploadAt { get; set; }

        // For charts / graphs
        public List<MetricDataPoint> FramesPerDay { get; set; } = new();
        public List<MetricDataPoint> PatientsPerDay { get; set; } = new();
    }
}
