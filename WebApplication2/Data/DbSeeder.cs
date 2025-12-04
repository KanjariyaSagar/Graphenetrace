using System;
using System.Linq;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public static class DbSeeder
    {
        public static void Seed(ApplicationDbContext db)
        {
            // If there is already data, don't seed again
            if (db.Users.Any())
                return;

            // ------------------- USERS --------------------
            var clinician = new User
            {
                FullName = "Dr. Chris Taylor",
                Email = "clinician@example.com",
                Role = "Clinician",
                Age = 45,
                Gender = "Male"
            };

            var mary = new User
            {
                FullName = "Mary Smith",
                Email = "mary.smith@example.com",
                Role = "Patient",
                Age = 68,
                Gender = "Female"
            };

            var alex = new User
            {
                FullName = "Alex Johnson",
                Email = "alex.johnson@example.com",
                Role = "Patient",
                Age = 54,
                Gender = "Male"
            };

            var james = new User
            {
                FullName = "James Patel",
                Email = "james.patel@example.com",
                Role = "Patient",
                Age = 60,
                Gender = "Male"
            };

            db.Users.AddRange(clinician, mary, alex, james);
            db.SaveChanges();

            //  generated IDs
            var clinicianId = clinician.UserID;
            var maryId = mary.UserID;
            var alexId = alex.UserID;
            var jamesId = james.UserID;

            // ------------------- CLINICIAN ↔ PATIENT LINKS --------------------
            db.ClinicianPatients.AddRange(
                new ClinicianPatient
                {
                    ClinicianID = clinicianId,
                    PatientID = maryId,
                    Condition = "Diabetic foot ulcer",
                    AssignedAt = DateTime.UtcNow.AddDays(-30)
                },
                new ClinicianPatient
                {
                    ClinicianID = clinicianId,
                    PatientID = alexId,
                    Condition = "Peripheral neuropathy",
                    AssignedAt = DateTime.UtcNow.AddDays(-20)
                },
                new ClinicianPatient
                {
                    ClinicianID = clinicianId,
                    PatientID = jamesId,
                    Condition = "Post-surgery monitoring",
                    AssignedAt = DateTime.UtcNow.AddDays(-10)
                }
            );

            db.SaveChanges();

            // ------------------- SENSOR FRAMES + METRICS --------------------
            // Mary – 3 sessions
            var m1 = new SensorFrame
            {
                PatientID = maryId,
                Timestamp = DateTime.UtcNow.AddHours(-6),
                PayloadCsv = "demo,mary,1",
                SourceFile = "mary_session1.csv"
            };
            var m2 = new SensorFrame
            {
                PatientID = maryId,
                Timestamp = DateTime.UtcNow.AddHours(-3),
                PayloadCsv = "demo,mary,2",
                SourceFile = "mary_session2.csv"
            };
            var m3 = new SensorFrame
            {
                PatientID = maryId,
                Timestamp = DateTime.UtcNow.AddHours(-2),
                PayloadCsv = "demo,mary,3",
                SourceFile = "mary_session3.csv"
            };

            // Alex – 2 sessions
            var a1 = new SensorFrame
            {
                PatientID = alexId,
                Timestamp = DateTime.UtcNow.AddHours(-7),
                PayloadCsv = "demo,alex,1",
                SourceFile = "alex_session1.csv"
            };
            var a2 = new SensorFrame
            {
                PatientID = alexId,
                Timestamp = DateTime.UtcNow.AddHours(-4),
                PayloadCsv = "demo,alex,2",
                SourceFile = "alex_session2.csv"
            };

            // James – 2 sessions
            var j1 = new SensorFrame
            {
                PatientID = jamesId,
                Timestamp = DateTime.UtcNow.AddHours(-8),
                PayloadCsv = "demo,james,1",
                SourceFile = "james_session1.csv"
            };
            var j2 = new SensorFrame
            {
                PatientID = jamesId,
                Timestamp = DateTime.UtcNow.AddHours(-5),
                PayloadCsv = "demo,james,2",
                SourceFile = "james_session2.csv"
            };

            db.SensorFrames.AddRange(m1, m2, m3, a1, a2, j1, j2);
            db.SaveChanges();

            // After SaveChanges, DataID values are generated
            db.FrameMetrics.AddRange(
                // Mary
                new FrameMetric { DataID = m1.DataID, PeakPressureIndex = 75, ContactAreaPct = 36 },
                new FrameMetric { DataID = m2.DataID, PeakPressureIndex = 82, ContactAreaPct = 41 },
                new FrameMetric { DataID = m3.DataID, PeakPressureIndex = 78, ContactAreaPct = 39 },

                // Alex
                new FrameMetric { DataID = a1.DataID, PeakPressureIndex = 72, ContactAreaPct = 38 },
                new FrameMetric { DataID = a2.DataID, PeakPressureIndex = 76, ContactAreaPct = 37 },

                // James
                new FrameMetric { DataID = j1.DataID, PeakPressureIndex = 90, ContactAreaPct = 44 },
                new FrameMetric { DataID = j2.DataID, PeakPressureIndex = 95, ContactAreaPct = 45 }
            );

            db.SaveChanges();

            // ------------------- OPTIONAL: COMMENTS / ALERTS --------------------
            // You can add demo Alerts / Comments here if your models exist.
        }
    }
}
