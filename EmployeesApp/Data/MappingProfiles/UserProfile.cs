using AutoMapper;
using EmployeesApp.Data.ViewModels;
using EmployeesApp.Models;

namespace EmployeesApp.Data.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Employee, EmployeeViewModel>();
            CreateMap<EmployeeViewModel, Employee>();
        }
    }
}
