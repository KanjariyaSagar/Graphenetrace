using System;

namespace WebApplication2.Models.ViewModels
{
    public class UploadHistoryItemVM
    {
        public DateTime Timestamp { get; set; }
        public double Ppi { get; set; }              
        public double ContactAreaPct { get; set; }   
        public string Severity { get; set; } = "";
        public string SourceFile { get; set; } = "";

        public string TimestampText => Timestamp.ToString("dd-MM-yyyy HH:mm");
    }
}
