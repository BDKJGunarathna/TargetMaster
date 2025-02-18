using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TargetMaster.Models
{
    public class Employees
    {
        [Key]
        public int EmployeeId { get; set; }
        [Column(TypeName = "varchar=20")]
        public string EmployeeName { get; set; }
        [Column(TypeName = "varchar=20")]
        public string EmployeeRole { get; set; }
        
        [Column(TypeName = "varchar=20")]
        public string Department { get; set; }

        // Navigation properties
        public ICollection<Targets> TargetsAssignedTo { get; set; }
        public ICollection<Targets> TargetsAssignedBy { get; set; }
        public ICollection<TargetProgress> TargetProgresses { get; set; }
        public ICollection<PerformanceEvaluations> PerformanceEvaluations { get; set; }
    }
}
