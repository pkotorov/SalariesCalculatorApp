using AutoMapper;
using EmployeesApp.Data.Helpers;
using EmployeesApp.Data.Services;
using EmployeesApp.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeesApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeesService employeesService;
        private readonly IMapper mapper;

        public HomeController(IEmployeesService employeesService, IMapper mapper)
        {
            this.employeesService = employeesService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Calculate(EmployeeViewModel employee)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("Index", employee);
            }

            var employeeAfterCalculations = Calculator.CalculateNetPayAndTaxes(employee);

            return this.View(employeeAfterCalculations);
        }

        [HttpPost]
        public async Task<IActionResult> Save(EmployeeViewModel employee)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(employee);
            }

            await this.employeesService.AddEmployeeAsync(employee);

            return this.RedirectToAction("All", "Employees");
        }
    }
}
