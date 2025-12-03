using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // ===== DbSets =====

        public DbSet<User> Users { get; set; }
        public DbSet<ClinicianPatient> ClinicianPatients { get; set; }
        public DbSet<SensorFrame> SensorFrames { get; set; }
        public DbSet<FrameMetric> FrameMetrics { get; set; }
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentReply> CommentReplies { get; set; }
        public DbSet<Log> Logs { get; set; }

        // ===== Model configuration =====

        protected override void OnModelCreating(ModelBuilder b)
        {
            base.OnModelCreating(b);

            // ----- Users -----
            b.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            b.Entity<User>()
                .Property(u => u.Role)
                .HasMaxLength(20);

            // ----- ClinicianPatient join table (Clinician ↔ Patient) -----
            // Composite primary key (ClinicianID + PatientID)
            b.Entity<ClinicianPatient>(entity =>
            {
                entity.HasKey(cp => new { cp.ClinicianID, cp.PatientID });

                entity.HasOne(cp => cp.Clinician)
                      .WithMany()
                      .HasForeignKey(cp => cp.ClinicianID)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(cp => cp.Patient)
                      .WithMany()
                      .HasForeignKey(cp => cp.PatientID)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // ----- Sensor frames + metrics -----
            b.Entity<SensorFrame>()
                .HasIndex(sf => new { sf.PatientID, sf.Timestamp });

            // 1:1 FrameMetric ↔ SensorFrame via DataID
            b.Entity<FrameMetric>()
                .HasIndex(fm => fm.DataID)
                .IsUnique();

            b.Entity<FrameMetric>()
                .HasOne(fm => fm.Data)
                .WithOne(sf => sf.Metric)
                .HasForeignKey<FrameMetric>(fm => fm.DataID)
                .OnDelete(DeleteBehavior.Cascade);

            // ----- Alerts -----
            // Keep patient, but do not cascade delete (avoid multiple cascade paths)
            b.Entity<Alert>()
                .HasOne(a => a.Patient)
                .WithMany()
                .HasForeignKey(a => a.PatientID)
                .OnDelete(DeleteBehavior.Restrict);

            // Optional link to frame; if frame deleted, set null on alert
            b.Entity<Alert>()
                .HasOne(a => a.Data)
                .WithMany()
                .HasForeignKey(a => a.DataID)
                .OnDelete(DeleteBehavior.SetNull);

            // ----- Comments -----
            b.Entity<Comment>()
                .HasOne(c => c.Patient)
                .WithMany()
                .HasForeignKey(c => c.PatientID)
                .OnDelete(DeleteBehavior.Restrict);

            b.Entity<Comment>()
                .HasOne(c => c.Data)
                .WithMany()
                .HasForeignKey(c => c.DataID)
                .OnDelete(DeleteBehavior.SetNull);

            // ----- Comment replies -----
            b.Entity<CommentReply>()
                .HasOne(r => r.Comment)
                .WithMany(c => c.Replies)
                .HasForeignKey(r => r.CommentID)
                .OnDelete(DeleteBehavior.Cascade);

            b.Entity<CommentReply>()
                .HasOne(r => r.Clinician)
                .WithMany()
                .HasForeignKey(r => r.ClinicianID)
                .OnDelete(DeleteBehavior.Restrict);

            // ----- Logs -----
            b.Entity<Log>()
                .HasOne(l => l.User)
                .WithMany()
                .HasForeignKey(l => l.UserID)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
