using EmployeesApp.Data.Common;
using EmployeesApp.Data.ViewModels;
using System;

namespace EmployeesApp.Data.Helpers
{
    public static class Calculator
    {
        public static EmployeeViewModel CalculateNetPayAndTaxes(EmployeeViewModel employee)
        {
            var grossPay = employee.GrossPay;

            if (grossPay < 0 || grossPay > 100000)
            {
                throw new ArgumentOutOfRangeException("Value must be between 0 and 100.000.");
            }

            if (grossPay <= GlobalConstants.MinimumTreshold)
            {
                employee.NetPay = grossPay;
                employee.IncomeTax = 0;
                employee.HealthAndSocialInsuranceTax = 0;
                employee.TaxesTotal = 0;
            }
            else
            {
                var grossPayOverOneThousand = grossPay - GlobalConstants.MinimumTreshold;
                var incomeTax = grossPayOverOneThousand * GlobalConstants.IncomeTaxValue;

                decimal payBetweenMinimumAndMaximumPayTreshold;

                if (grossPay > GlobalConstants.MaximalTreshold)
                {
                    payBetweenMinimumAndMaximumPayTreshold = GlobalConstants.FixedPayBetweenMinAndMaxTreshold;
                }
                else
                {
                    payBetweenMinimumAndMaximumPayTreshold = grossPayOverOneThousand;
                }

                var healthAndSocialInsuranceTax = payBetweenMinimumAndMaximumPayTreshold * GlobalConstants.HealthAndSocialInsuranceTaxesValue;
                var taxesTotal = incomeTax + healthAndSocialInsuranceTax;

                employee.IncomeTax = incomeTax;
                employee.HealthAndSocialInsuranceTax = healthAndSocialInsuranceTax;
                employee.TaxesTotal = taxesTotal;
                employee.NetPay = grossPay - taxesTotal;
            }

            return employee;
        }
    }
}
