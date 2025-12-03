using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class FrameMetric
    {
        [Key, ForeignKey("Data")]
        public int DataID { get; set; }    //  int, same as SensorFrame.DataID

        public int PeakPressureIndex { get; set; }
        public decimal ContactAreaPct { get; set; }

        // Navigation back to the frame
        public SensorFrame Data { get; set; } = default!;
    }
}
