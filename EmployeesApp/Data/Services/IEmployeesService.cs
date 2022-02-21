using EmployeesApp.Data.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeesApp.Data.Services
{
    public interface IEmployeesService
    {
        Task<IEnumerable<EmployeeViewModel>> GetAllEmployeesAsync();

        Task<EmployeeViewModel> GetEmployeeByIdAsync(int id);

        Task AddEmployeeAsync(EmployeeViewModel employee);

        Task UpdateEmployeeAsync(EmployeeViewModel employee);

        Task DeleteAsync(int id);
    }
}
