using AutoMapper;
using EmployeesApp.Data.Helpers;
using EmployeesApp.Data.ViewModels;
using EmployeesApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApp.Data.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly AppDbContext appDbContext;
        private readonly IMapper mapper;

        public EmployeesService(AppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }

        public async Task AddEmployeeAsync(EmployeeViewModel employee)
        {
            employee = Calculator.CalculateNetPayAndTaxes(employee);

            var employeeToAdd = this.mapper.Map<Employee>(employee);

            await this.appDbContext.Employees.AddAsync(employeeToAdd);
            await this.appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await this.appDbContext.Set<Employee>().FirstOrDefaultAsync(e => e.Id == id);
            EntityEntry entityEntry = this.appDbContext.Entry<Employee>(entity);
            entityEntry.State = EntityState.Deleted;

            await this.appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<EmployeeViewModel>> GetAllEmployeesAsync()
        {
            var allEmployees = await this.appDbContext.Employees.OrderBy(f => f.FirstName).ThenBy(f => f.FamilyName).ToListAsync();

            var result = this.mapper.Map<IEnumerable<EmployeeViewModel>>(allEmployees);

            return result;
        }

        public async Task<EmployeeViewModel> GetEmployeeByIdAsync(int id)
        {
            var employeeById = await this.appDbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);

            var result = this.mapper.Map<EmployeeViewModel>(employeeById);

            return result;
        }

        public async Task UpdateEmployeeAsync(EmployeeViewModel employee)
        {
            employee = Calculator.CalculateNetPayAndTaxes(employee);

            var employeeDto = this.mapper.Map<Employee>(employee);

            EntityEntry entityEntry = this.appDbContext.Entry<Employee>(employeeDto);
            entityEntry.State = EntityState.Modified;

            await this.appDbContext.SaveChangesAsync();
        }
    }
}
