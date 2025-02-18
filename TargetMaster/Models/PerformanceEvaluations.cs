using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TargetMaster.Models
{
    public class PerformanceEvaluations
    {
        [Key]
        public int EvaluationId { get; set; }
        [Column]
        [ForeignKey("Employees.EmployeeId")]
        public int EmployeeId { get; set; }
        [Column]
        public decimal Progress { get; set; }
        [Column]
        [DataType(DataType.Date)]
        public DateTime DateUpdated { get; set; }

        // Navigation property
        public Employees Employee { get; set; }
    }
}
