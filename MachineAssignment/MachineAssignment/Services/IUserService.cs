using MachineAssignment.Models;
using MachineAssignment.Models.Dto;

namespace MachineAssignment.Services
{
    public interface IUserService
    {
        Task<Employees> UserExists(RegisterUserDto registerUser);
        Task<bool> UserLogin(Employees employee);
        Task<int> UserRegisteration(Employees employee);
    }
}
