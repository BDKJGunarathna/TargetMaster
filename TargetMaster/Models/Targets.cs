using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TargetMaster.Models
    
{
    public class Targets
    {
        [Key]
        public int TargetId { get; set; }

        [Column (TypeName ="nvarchar(12)")]
        public string Title { get; set; }

        [Column(TypeName ="nvarchar(100)")]
        public string Description { get; set; }

        [Column(TypeName ="int(10)")]
        public int? Weightage { get; set; }
        [Column]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Column]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [ForeignKey("Employees.EmployeeId")]

        [Column ]
        public int AssignedTo { get; set; }


        [Column]
        [ForeignKey("Employees.EmployeeId")]
        public string AssignedBy { get; set; }

        public string Status { get; set; }

        public int EmployeeId { get; set; }
        // Navigation properties
        public Employees AssignedEmployee { get; set; }
        public Employees AssignedByEmployee { get; set; }
        public ICollection<TargetProgress> TargetProgresses { get; set; }

    }
}
