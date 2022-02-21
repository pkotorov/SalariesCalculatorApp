using AutoMapper;
using EmployeesApp.Data.Services;
using EmployeesApp.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApp.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeesService employeesService;
        private readonly IMapper mapper;

        public EmployeesController(IEmployeesService employeesService, IMapper mapper)
        {
            this.employeesService = employeesService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Details(int id)
        {
            var employee = await this.employeesService.GetEmployeeByIdAsync(id);

            if (employee == null)
            {
                return this.View(nameof(NotFound));
            }

            var employeeDto = this.mapper.Map<EmployeeViewModel>(employee);

            return this.View(employeeDto);
        }

        public async Task<IActionResult> All()
        {
            var employees = await this.employeesService.GetAllEmployeesAsync();

            return this.View(employees);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var employee = await this.employeesService.GetEmployeeByIdAsync(id);

            if (employee == null)
            {
                return this.View(nameof(NotFound));
            }

            return this.View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await this.employeesService.GetEmployeeByIdAsync(id);

            if (employee == null)
            {
                return this.View(nameof(NotFound));
            }

            await this.employeesService.DeleteAsync(id);

            return this.RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var employee = await this.employeesService.GetEmployeeByIdAsync(id);

            if (employee == null)
            {
                return this.View(nameof(NotFound));
            }

            return this.View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeViewModel employee)
        {
            if (!ModelState.IsValid)
            {
                return this.View(employee);
            }

            await this.employeesService.UpdateEmployeeAsync(employee);

            return this.RedirectToAction("All", "Employees", employee.Id);
        }
    }
}
