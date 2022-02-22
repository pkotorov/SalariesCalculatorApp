using EmployeesApp.Data.Helpers;
using EmployeesApp.Data.ViewModels;
using System;
using Xunit;

namespace EmployeesApp.Tests
{
    public class Calculation
    {
        [Fact]
        public void Should_Not_Calculate_Taxes_When_GrossPay_Is_Less_Than_One_Thousand()
        {
            var employee = new EmployeeViewModel
            {
                GrossPay = 950
            };

            employee = Calculator.CalculateNetPayAndTaxes(employee);

            Assert.Equal(0, employee.TaxesTotal);
        }

        [Fact]
        public void Should_Not_Calculate_Taxes_When_GrossPay_Is_Equal_To_One_Thousand()
        {
            var employee = new EmployeeViewModel
            {
                GrossPay = 1000
            };

            employee = Calculator.CalculateNetPayAndTaxes(employee);

            Assert.Equal(0, employee.TaxesTotal);
        }

        [Fact]
        public void Should_Not_Calculate_Taxes_When_GrossPay_Is_Equal_To_Zero()
        {
            var employee = new EmployeeViewModel
            {
                GrossPay = 0
            };

            employee = Calculator.CalculateNetPayAndTaxes(employee);

            Assert.Equal(0, employee.TaxesTotal);
        }

        [Fact]
        public void Should_Calculate_Correctly_Taxes_When_GrossPay_Is_Between_1001_And_2999()
        {
            var employee = new EmployeeViewModel
            {
                GrossPay = 1500
            };

            employee = Calculator.CalculateNetPayAndTaxes(employee);

            Assert.Equal(125, employee.TaxesTotal);
        }

        [Fact]
        public void Should_Calculate_Correctly_Taxes_When_GrossPay_Is_Equal_To_Three_Tousand()
        {
            var employee = new EmployeeViewModel
            {
                GrossPay = 3000
            };

            employee = Calculator.CalculateNetPayAndTaxes(employee);

            Assert.Equal(500, employee.TaxesTotal);
        }

        [Fact]
        public void Should_Calculate_Correctly_Taxes_When_GrossPay_Is_More_Than_Three_Tousand()
        {
            var employee = new EmployeeViewModel
            {
                GrossPay = 3500
            };

            employee = Calculator.CalculateNetPayAndTaxes(employee);

            Assert.Equal(550, employee.TaxesTotal);
        }

        [Fact]
        public void Should_Not_Calculate_IncomeTax_When_GrossPay_Is_Less_Than_One_Thousand()
        {
            var employee = new EmployeeViewModel
            {
                GrossPay = 950
            };

            employee = Calculator.CalculateNetPayAndTaxes(employee);

            Assert.Equal(0, employee.IncomeTax);
        }

        [Fact]
        public void Should_Not_Calculate_IncomeTax_When_GrossPay_Is_Equal_To_One_Thousand()
        {
            var employee = new EmployeeViewModel
            {
                GrossPay = 1000
            };

            employee = Calculator.CalculateNetPayAndTaxes(employee);

            Assert.Equal(0, employee.IncomeTax);
        }

        [Fact]
        public void Should_Not_Calculate_IncomeTax_When_GrossPay_Is_Equal_To_Zero()
        {
            var employee = new EmployeeViewModel
            {
                GrossPay = 0
            };

            employee = Calculator.CalculateNetPayAndTaxes(employee);

            Assert.Equal(0, employee.IncomeTax);
        }

        [Fact]
        public void Should_Calculate_Correctly_IncomeTax_When_GrossPay_Is_Between_1001_And_2999()
        {
            var employee = new EmployeeViewModel
            {
                GrossPay = 1500
            };

            employee = Calculator.CalculateNetPayAndTaxes(employee);

            Assert.Equal(50, employee.IncomeTax);
        }

        [Fact]
        public void Should_Calculate_Correctly_IncomeTax_When_GrossPay_Is_Equal_To_Three_Tousand()
        {
            var employee = new EmployeeViewModel
            {
                GrossPay = 3000
            };

            employee = Calculator.CalculateNetPayAndTaxes(employee);

            Assert.Equal(200, employee.IncomeTax);
        }

        [Fact]
        public void Should_Calculate_Correctly_IncomeTax_When_GrossPay_Is_More_Than_Three_Tousand()
        {
            var employee = new EmployeeViewModel
            {
                GrossPay = 3500
            };

            employee = Calculator.CalculateNetPayAndTaxes(employee);

            Assert.Equal(250, employee.IncomeTax);
        }

        [Fact]
        public void Should_Not_Calculate_Health_And_Social_Insurance_Taxes_When_GrossPay_Is_Less_Than_One_Thousand()
        {
            var employee = new EmployeeViewModel
            {
                GrossPay = 950
            };

            employee = Calculator.CalculateNetPayAndTaxes(employee);

            Assert.Equal(0, employee.HealthAndSocialInsuranceTax);
        }

        [Fact]
        public void Should_Not_Calculate_Health_And_Social_Insurance_Taxes_When_GrossPay_Is_Equal_To_One_Thousand()
        {
            var employee = new EmployeeViewModel
            {
                GrossPay = 1000
            };

            employee = Calculator.CalculateNetPayAndTaxes(employee);

            Assert.Equal(0, employee.HealthAndSocialInsuranceTax);
        }

        [Fact]
        public void Should_Not_Calculate_Health_And_Social_Insurance_Taxes_When_GrossPay_Is_Equal_To_Zero()
        {
            var employee = new EmployeeViewModel
            {
                GrossPay = 0
            };

            employee = Calculator.CalculateNetPayAndTaxes(employee);

            Assert.Equal(0, employee.HealthAndSocialInsuranceTax);
        }

        [Fact]
        public void Should_Calculate_Correctly_Health_And_Social_Insurance_Taxes_When_GrossPay_Is_Between_1001_And_2999()
        {
            var employee = new EmployeeViewModel
            {
                GrossPay = 1500
            };

            employee = Calculator.CalculateNetPayAndTaxes(employee);

            Assert.Equal(75, employee.HealthAndSocialInsuranceTax);
        }

        [Fact]
        public void Should_Calculate_Correctly_Health_And_Social_Insurance_Taxes_When_GrossPay_Is_Equal_To_Three_Tousand()
        {
            var employee = new EmployeeViewModel
            {
                GrossPay = 3000
            };

            employee = Calculator.CalculateNetPayAndTaxes(employee);

            Assert.Equal(300, employee.HealthAndSocialInsuranceTax);
        }

        [Fact]
        public void Should_Calculate_Correctly_Health_And_Social_Insurance_Taxes_When_GrossPay_Is_More_Than_Three_Tousand()
        {
            var employee = new EmployeeViewModel
            {
                GrossPay = 3500
            };

            employee = Calculator.CalculateNetPayAndTaxes(employee);

            Assert.Equal(300, employee.HealthAndSocialInsuranceTax);
        }

        [Fact]
        public void Should_Calculate_NetPay_Correctly_When_GrossPay_Is_Less_Than_One_Thousand()
        {
            var employee = new EmployeeViewModel
            {
                GrossPay = 950
            };

            employee = Calculator.CalculateNetPayAndTaxes(employee);

            Assert.Equal(950, employee.NetPay);
        }

        [Fact]
        public void Should_Calculate_NetPay_Correctly_When_GrossPay_Is_Equal_To_One_Thousand()
        {
            var employee = new EmployeeViewModel
            {
                GrossPay = 1000
            };

            employee = Calculator.CalculateNetPayAndTaxes(employee);

            Assert.Equal(1000, employee.NetPay);
        }

        [Fact]
        public void Should_Calculate_NetPay_Correctly_When_GrossPay_Is_Equal_To_Zero()
        {
            var employee = new EmployeeViewModel
            {
                GrossPay = 0
            };

            employee = Calculator.CalculateNetPayAndTaxes(employee);

            Assert.Equal(0, employee.NetPay);
        }

        [Fact]
        public void Should_Calculate_NetPay_Correctly_When_GrossPay_Is_Between_1001_And_2999()
        {
            var employee = new EmployeeViewModel
            {
                GrossPay = 1500
            };

            employee = Calculator.CalculateNetPayAndTaxes(employee);

            Assert.Equal(1375, employee.NetPay);
        }

        [Fact]
        public void Should_Calculate_Correctly_NetPay_When_GrossPay_Is_Equal_To_Three_Tousand()
        {
            var employee = new EmployeeViewModel
            {
                GrossPay = 3000
            };

            employee = Calculator.CalculateNetPayAndTaxes(employee);

            Assert.Equal(2500, employee.NetPay);
        }

        [Fact]
        public void Should_Calculate_Correctly_NetPay_When_GrossPay_Is_More_Than_Three_Tousand()
        {
            var employee = new EmployeeViewModel
            {
                GrossPay = 3500
            };

            employee = Calculator.CalculateNetPayAndTaxes(employee);

            Assert.Equal(2950, employee.NetPay);
        }

        [Fact]
        public void Should_Throw_An_Error_When_GrossPay_Is_Less_Than_Zero()
        {
            var employee = new EmployeeViewModel
            {
                GrossPay = -1
            };

            Assert.Throws<ArgumentOutOfRangeException>(() => Calculator.CalculateNetPayAndTaxes(employee));
        }

        [Fact]
        public void Should_Throw_An_Error_When_GrossPay_Is_More_Than_One_Hundred_Thousand()
        {
            var employee = new EmployeeViewModel
            {
                GrossPay = 100001
            };

            Assert.Throws<ArgumentOutOfRangeException>(() => Calculator.CalculateNetPayAndTaxes(employee));
        }
    }
}
