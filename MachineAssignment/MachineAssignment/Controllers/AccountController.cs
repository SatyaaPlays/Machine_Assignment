using AutoMapper;
using MachineAssignment.Models;
using MachineAssignment.Models.Dto;
using MachineAssignment.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using NuGet.Protocol.Plugins;

namespace MachineAssignment.Controllers
{
    public class AccountController : Controller
    {
        readonly IUserService _userService;
        readonly IMapper _mapper;
        public AccountController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserDto registerUser)
        {
            var employeeExist = await _userService.UserExists(registerUser);
            if (employeeExist != null)
            {
                return View();
            }
            else
            {
                var employee = _mapper.Map<Employees>(registerUser);
                int employeeInserted = await _userService.UserRegisteration(employee);
                if (employeeInserted <= 0)
                {
                    return View();
                }
                else
                {

                    return RedirectToAction("Login");
                }
            }
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserDto loginUser)
        {
            var employee = _mapper.Map<Employees>(loginUser);
            HttpContext.Session.SetString("Email", loginUser.EmployeeEmail);
            bool employeelogged = await _userService.UserLogin(employee);
            if (employeelogged == false)
            {
                return View();
            }
            else
            {
                return RedirectToAction("GetAllProducts", "Product");
            }
        }


        public IActionResult Logout()
        {
            //HttpContext.Session.Remove("Email");
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
