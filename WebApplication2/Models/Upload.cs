namespace WebApplication2.Models
{
    public class Upload
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; } = default!;
        public DateTime UploadedAt { get; set; }
        public string Frames { get; set; } = "";
        public string Status { get; set; } = "";
    }
}
