using System;
using System.Collections.Generic;

namespace WebApplication2.Models.ViewModels
{
    public class MetricsViewModel
    {
        // Time range currently selected
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        // Which metric is chosen in the dropdown: "ppi", "ca", "uploads"
        public string SelectedMetric { get; set; } = "ppi";

        // Data points for each metric type
        public List<MetricDataPoint> MetricPoints { get; set; } = new();
        public List<MetricDataPoint> ContactAreaPoints { get; set; } = new();
        public List<MetricDataPoint> UploadCountPoints { get; set; } = new();

        // Optional reason text if there is no data to show
        public string? NoDataReason { get; set; }
    }
}
