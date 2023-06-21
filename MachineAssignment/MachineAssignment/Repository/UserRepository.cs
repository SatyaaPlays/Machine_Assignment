using MachineAssignment.Context;
using MachineAssignment.Models;
using MachineAssignment.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace MachineAssignment.Repository
{
    public class UserRepository : IUserRepository
    {
        readonly ApplicationDbContext _applicationDbContext;
        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Employees> UserExists(RegisterUserDto registerUser)
        {
            return await _applicationDbContext.tbl_Employees.Where(user => user.EmployeeEmail == registerUser.EmployeeEmail).SingleOrDefaultAsync();
        }

        public async Task<bool> UserLogin(Employees employee)
        {
            return await _applicationDbContext.tbl_Employees.AnyAsync(e => e.EmployeeEmail == employee.EmployeeEmail && e.EmployeePassword == employee.EmployeePassword);
        }

        public async Task<int> UserRegisteration(Employees employee)
        {
            await _applicationDbContext.AddAsync(employee);
            return await _applicationDbContext.SaveChangesAsync();
        }
    }
}
