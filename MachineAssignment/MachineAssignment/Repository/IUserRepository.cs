using MachineAssignment.Models;
using MachineAssignment.Models.Dto;

namespace MachineAssignment.Repository
{
    public interface IUserRepository
    {
        Task<Employees> UserExists(RegisterUserDto registerUser);
        Task<bool> UserLogin(Employees employee);
        Task<int> UserRegisteration(Employees employee);
    }
}
