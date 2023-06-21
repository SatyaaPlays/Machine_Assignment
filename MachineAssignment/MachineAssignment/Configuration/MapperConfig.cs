using AutoMapper;
using MachineAssignment.Models;
using MachineAssignment.Models.Dto;

namespace MachineAssignment.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Employees, RegisterUserDto>().ReverseMap();
            CreateMap<Employees, LoginUserDto>().ReverseMap();
        }
    }
}
