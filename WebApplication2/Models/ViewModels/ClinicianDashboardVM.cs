using System;
using System.Collections.Generic;

namespace WebApplication2.Models.ViewModels
{
    public class ClinicianDashboardVM
    {
        // Top header text
        public string? ClinicianName { get; set; }

        // "Last Updated: ..." line
        public string LastUpdatedText { get; set; } = string.Empty;

        // KPI cards
        public int TotalFrames { get; set; }          // @Model.TotalFrames
        public int TodayDateLabel { get; set; }       // @Model.TodayDateLabel  (number shown in "+X today")
        public int TodaysUploads { get; set; }        // @Model.TodaysUploads
        public int DistinctPatients { get; set; }     // @Model.DistinctPatients

        // Last upload card
        public string LastUploadTimeText { get; set; } = string.Empty;  // @Model.LastUploadTimeText
        public string LastUploadDateText { get; set; } = string.Empty;  // @Model.LastUploadDateText

        // Frames overview card
        public int FramesToday { get; set; }                          // @Model.FramesToday
        public string FramesTodayLabel { get; set; } = string.Empty;  // @Model.FramesTodayLabel

        // Alerts box
        public List<AlertItemVM> Alerts { get; set; } = new();            // @Model.Alerts

        // Recent uploads table
        public List<RecentUploadVM> RecentUploads { get; set; } = new();  // @Model.RecentUploads

        // Notes textarea
        public string? Notes { get; set; }                            // @Model.Notes
    }

    // Single alert item used in the Alerts list
    public class AlertVM
    {
        public DateTime When { get; set; }                // @a.When.ToString(...)
        public string Title { get; set; } = string.Empty; // @a.Title
        public string Detail { get; set; } = string.Empty;// @a.Detail
    }

    // Single row in the "Recent Uploads" table
    public class RecentUploadVM
    {
        public string PatientName { get; set; } = string.Empty;   // @u.PatientName
        public DateTime UploadedAt { get; set; }                  // @u.UploadedAt
        public int Frames { get; set; }                           // @u.Frames
        public string StatusCss { get; set; } = string.Empty;     // @u.StatusCss
        public string Status { get; set; } = string.Empty;        // @u.Status
    }
}
