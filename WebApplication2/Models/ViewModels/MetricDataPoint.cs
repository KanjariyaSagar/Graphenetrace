using System;

namespace WebApplication2.Models.ViewModels
{
    public class MetricDataPoint
    {
        public DateTime Date { get; set; }

        // Label the charts use (e.g. "21 Nov")
        public string Label => Date.ToString("dd MMM");

        public double Value { get; set; }
    }
}
