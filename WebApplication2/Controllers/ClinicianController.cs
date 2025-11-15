using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models.ViewModels;

namespace WebApplication2.Controllers
{
    //[Authorize(Roles = "Clinician,Admin")]
    public class ClinicianController : Controller
    {
        // ===================== DASHBOARD =====================
        // GET: /Clinician/Index
        public IActionResult Index()
        {
            var model = new ClinicianDashboardVM
            {
                ClinicianName = User.Identity?.Name ?? "Clinician",
                Notes = "Demo dashboard data – replace with real database queries.",

                // demo scalar values
                TotalFrames = 0,
                TodaysUploads = 0,
                DistinctPatients = 0,
                LastUploadAt = null
            };

            model.KpiCards.Add(new KpiCardVM
            {
                Title = "Total Frames",
                Value = model.TotalFrames.ToString(),
                BadgeText = "",
                BadgeCss = "badge-secondary",
                Description = "Total sensor frames ingested",
                Hint = ""
            });

            model.KpiCards.Add(new KpiCardVM
            {
                Title = "Today’s Uploads",
                Value = model.TodaysUploads.ToString(),
                BadgeText = "",
                BadgeCss = "badge-secondary",
                Description = "Uploads received in the last 24 hours",
                Hint = ""
            });

            model.KpiCards.Add(new KpiCardVM
            {
                Title = "Distinct Patients",
                Value = model.DistinctPatients.ToString(),
                BadgeText = "",
                BadgeCss = "badge-secondary",
                Description = "Patients with at least one upload",
                Hint = ""
            });

            // Keep lists empty for now – views can still foreach safely
            model.RecentUploads = new List<RecentUploadVM>();
            model.RecentAlerts = new List<AlertVM>();

            return View(model);
        }

        // ===================== METRICS =====================
        // GET: /Clinician/Metrics
        public IActionResult Metrics()
        {
            var model = new ClinicianMetricsVM
            {
                SelectedMetric = "PPI",
                QuickRange = "Today"
            };

            // later: fill TimeLabels, Values, etc. from DB
            return View(model);
        }

        // ===================== PATIENT LIST =====================
        // GET: /Clinician/Patients
        public IActionResult Patients()
        {
            var model = new ClinicianPatientsVM
            {
                Search = "",
                Sort = "newest",
                StatusFilter = "all",
                Patients = new List<ClinicianPatientRowVM>()
            };

            return View(model);
        }

        // ===================== PATIENT DETAILS =====================
        // GET: /Clinician/PatientDetails/5
        public IActionResult PatientDetails(int id)
        {
            var model = new ClinicianPatientReportVM
            {
                PatientId = id,
                Name = "Demo Patient",
                Age = 70,
                Gender = "F",
                Condition = "Pressure ulcer risk",
                AssignedAt = DateTime.UtcNow.AddDays(-3),
                LastCheckText = "No checks yet",
                Status = "Unknown",
                TotalUploads = 0,
                LatestPeakPressureIndex = 0,
                LatestContactAreaPct = 0,
                RiskScore = "Unknown",
                RiskCss = "badge-secondary",
                RecentAlerts = new List<ClinicianPatientAlertRowVM>(),
                UploadHistory = new List<ClinicianPatientUploadRowVM>()
            };

            return View(model);
        }

        // ===================== ALERTS =====================
        // GET: /Clinician/Alerts
        public IActionResult Alerts()
        {
            // View expects IEnumerable<AlertVM>
            var alerts = new List<AlertVM>();
            return View(alerts);
        }

        // ===================== COMMENTS =====================
        // GET: /Clinician/Comments
        public IActionResult Comments()
        {
            // you can later pass a comments VM here
            return View();
        }
    }
}
