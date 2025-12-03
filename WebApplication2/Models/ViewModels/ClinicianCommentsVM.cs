using System.Collections.Generic;

namespace WebApplication2.Models.ViewModels
{
    public class ClinicianCommentsVM
    {
        public string ClinicianName { get; set; } = string.Empty;

        public int TotalComments { get; set; }
        public int Last7DaysComments { get; set; }
        public int FollowUpCount { get; set; }

        public string? SelectedCategory { get; set; }  // "all", "general", "followup", "action"
        public List<CommentItemVM> Comments { get; set; } = new();
    }
}
