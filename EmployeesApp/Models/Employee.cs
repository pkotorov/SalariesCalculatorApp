using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeesApp.Models
{
    public class Employee 
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Име")]
        [Required(ErrorMessage = "Въвеждането на име е задължително!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Името трябва да е между 3 и 50 символа!")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Въвеждането на на фамилно име е задължително!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Фамилното име трябва да е между 3 и 50 символа!")]
        public string FamilyName { get; set; }

        [Display(Name = "Брутно заплата")]
        [Required(ErrorMessage = "Въвеждането на брутна заплата е задължително!")]
        [Range(0, 100000, ErrorMessage = "Брутната заплата трябва да е между 0 и 100.000")]
        public decimal GrossPay { get; set; }

        public decimal NetPay { get; set; }

        public decimal IncomeTax { get; set; }

        public decimal HealthAndSocialInsuranceTax { get; set; }

        public decimal TaxesTotal { get; set; }
    }
}
