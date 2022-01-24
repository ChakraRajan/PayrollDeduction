using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeeDeductionCalculation.Models
{
    public class Employee
    {
        [Required(ErrorMessage = "Please enter Employee name.")]
        [DisplayName("Employee Name:")]
        public string EmployeeName { get; set; }

        public List<Dependent> EmployeeDependents { get; set; } = new List<Dependent>();
    }

    public class Dependent
    {
        [DisplayName("Dependent Name: ")]
        [Required(ErrorMessage = "Please enter Dependent name.")]
        public string DependentName { get; set; }
    }
}