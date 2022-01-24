using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeDeductionCalculation.Models;

namespace EmployeeDeductionCalculation.Interface
{
    public interface IDeduction
    {
        decimal CalculateEmployeeDeduction(string empName);

        decimal CalculateDependentDeduction(List<Dependent> dependents);

    }
}
