using System;

namespace WebApplication2.Models.ViewModels
{
    public class KpiCardVM
    {
        public string Title { get; set; } = string.Empty;        
        public string Value { get; set; } = string.Empty;        
        public string BadgeText { get; set; } = string.Empty;    
        public string BadgeCss { get; set; } = string.Empty;     
        public string Description { get; set; } = string.Empty; 
    }
}
