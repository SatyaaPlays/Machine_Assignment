using MachineAssignment.Models;
using MachineAssignment.Models.Dto;
using MachineAssignment.Repository;

namespace MachineAssignment.Services
{
    public class UserService : IUserService
    {
        readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Employees> UserExists(RegisterUserDto registerUser)
        {
            return await _userRepository.UserExists(registerUser);
        }

        public async Task<bool> UserLogin(Employees employee)
        {
            return await _userRepository.UserLogin(employee);
        }

        public async Task<int> UserRegisteration(Employees employee)
        {
            return await _userRepository.UserRegisteration(employee);
        }
    }
}
