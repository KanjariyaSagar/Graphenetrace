namespace WebApplication2.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Condition { get; set; } = "";
        public DateTime LastCheckAt { get; set; }
        public string Status { get; set; } = "Stable";

        public ICollection<Upload> Uploads { get; set; } = new List<Upload>();
    }
}
