using System.ComponentModel.DataAnnotations;

namespace MachineAssignment.Models.Dto
{
    public class LoginUserDto
    {
        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string EmployeeEmail { get; set; }
        [MaxLength(10)]
        [MinLength(8)]
        [Required]
        [DataType(DataType.Password)]
        public string EmployeePassword { get; set; }
    }
}
