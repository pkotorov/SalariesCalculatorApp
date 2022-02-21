using EmployeesApp.Data.Helpers;
using EmployeesApp.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace EmployeesApp.Tests
{
    public class Calculation
    {
        [Fact]
        public void ShouldNotCalculateTaxesWhenGrossPayIsLessThanOneThousand()
        {
            var employee = new EmployeeViewModel
            {
                GrossPay = 950
            };

            employee = Calculator.CalculateNetPayAndTaxes(employee);

            Assert.Equal(0, employee.TaxesTotal);
        }

        [Fact]
        public void ShouldNotCalculateTaxesWhenGrossPayIsEqualToOneThousand()
        {
            var employee = new EmployeeViewModel
            {
                GrossPay = 1000
            };

            employee = Calculator.CalculateNetPayAndTaxes(employee);

            Assert.Equal(0, employee.TaxesTotal);
        }
    }
}
