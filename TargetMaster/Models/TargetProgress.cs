using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TargetMaster.Models
{
    public class TargetProgress
    {
        [Key]
        public int ProgressID { get; set; }
        [Column]
        [ForeignKey("Employees.EmployeeId")]
        public int TargetID { get; set; }

        public int EmployeeId { get; set; }
        [Column]
        public int Progress { get; set; }

        [Column]
        [DataType(DataType.Date)]
        public DateTime DateUpdated { get; set; }

        // Navigation properties
        public Targets Target { get; set; }
        public Employees Employee { get; set; }
    }
}
