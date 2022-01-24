using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeCalculationDeductionBusiness.Constants
{
    public class EmployeeConstant
    {
        public const decimal employeeSpecialDiscountPercentage = 10;
        public const decimal dependentSpecialDiscountPercentage  = 10;
        public const decimal employeeDeductionValue = 1000.00m;
        public const decimal dependentDeductionValue = 500.00m;
        public const decimal employeePayCheckValue = 2000.00m;
        public const int employeeNoOfPayChecks = 26;
        public const string discountType = "Percentage";
    }

    public enum DiscountType
    {
      Percentage,
      Fixed,        
    }

}