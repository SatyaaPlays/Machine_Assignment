using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MachineAssignment.Models
{
    public class Employees
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        [MaxLength(50)]
        public string EmployeeName { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string EmployeeEmail { get; set; }
        [Required]
        [MaxLength(50)]
        public string EmployeeAddress { get; set; }
        [MaxLength(10)]
        [MinLength(8)]
        [Required]
        [DataType(DataType.Password)]
        public string EmployeePassword { get; set; }
        [NotMapped]
        [MaxLength(10)]
        [MinLength(8)]
        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }


    }
}
