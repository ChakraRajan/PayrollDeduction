using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeCalculationDeductionBusiness.Constants;
using EmployeeDeductionCalculation.Models;
using EmployeeDeductionCalculation.Interface;

namespace EmployeeDeductionCalculation.Service
{
    public class DeductionCalculation  : IDeduction
    {
        public decimal CalculateEmployeeDeduction(string empName)
        {
            decimal employeeNetDeduction = EmployeeConstant.employeeDeductionValue;

            //If employee name starts with A, apply special discount
            if (empName.ToLower().StartsWith("a") && (EmployeeConstant.discountType == nameof(DiscountType.Percentage)))
            {
                employeeNetDeduction = (1 - EmployeeConstant.employeeDeductionValue / 100) * EmployeeConstant.employeeDeductionValue;
            }

            return employeeNetDeduction;
        }

        public decimal CalculateDependentDeduction(List<Dependent> dependents)
        {
            decimal dependentNetDeduction = EmployeeConstant.dependentDeductionValue;

            //int countDepStartwithA = dependents.Where(s => s != null && s.ToLower().StartsWith("a")).Count();
            int countDepStartwithA = dependents.Where(s => s != null && s.DependentName.ToLower().StartsWith("a")).Count();

            if (EmployeeConstant.discountType == nameof(DiscountType.Percentage))
            {
                //Starting with A
                dependentNetDeduction = ((1 - (EmployeeConstant.dependentSpecialDiscountPercentage / 100)) * (EmployeeConstant.dependentDeductionValue * countDepStartwithA));

                //Not starting with A
                dependentNetDeduction += (EmployeeConstant.dependentDeductionValue * (dependents.Count - countDepStartwithA));
            }

            return dependentNetDeduction;
        }
    }
}