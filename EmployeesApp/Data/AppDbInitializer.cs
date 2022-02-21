using EmployeesApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace EmployeesApp.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                if (!context.Employees.Any())
                {
                    context.Employees.AddRange(new List<Employee>()
                    {
                        new Employee()
                        {
                            FirstName = "Иван",
                            FamilyName = "Георгиев",
                            GrossPay = 950,
                            NetPay = 950
                        },
                        new Employee()
                        {
                            FirstName = "Петя",
                            FamilyName = "Иванова",
                            GrossPay = 3100,
                            NetPay = 2590,
                            IncomeTax = 210,
                            HealthAndSocialInsuranceTax = 300,
                            TaxesTotal = 510
                        }
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
