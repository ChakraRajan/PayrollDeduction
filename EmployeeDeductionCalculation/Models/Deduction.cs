using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace EmployeeDeductionCalculation.Models
{
    public class Deduction
    {
        [DisplayName("Employee Gross Salary")]
        public decimal TotalGrossSalary { get; set; }

        [DisplayName("Total Employee Deduction")]
        public decimal TotalEmployeeDeduction { get; set; }

        [DisplayName("Total Dependent Deduction")]
        public decimal TotalDependentDeduction { get; set; }

        [DisplayName("Empoyee Net Salary")]
        public decimal TotalNetSalary { get; set; }
    }

}