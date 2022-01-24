using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeDeductionCalculation.Models;
using EmployeeCalculationDeductionBusiness.Constants;
using EmployeeDeductionCalculation.Service;


namespace EmployeeDeductionCalculation.Controllers
{
    public class EmployeeController : Controller
    {
        static Employee emp = new Employee();

        // GET: Employee
        public ActionResult Index()
        {
            return View(emp);
        }

        //Display Add dependent partial view as Modal popup
        public ActionResult DisplayDependent()
        {
            Dependent empDep = new Dependent();

            return PartialView("_DependentDetails", empDep);            
        }

        //POST: To post the Add dependant values
        [HttpPost]
        public JsonResult AddDependent(string DependentName)
        {
            string status = "success";
            try
            {
                if (!string.IsNullOrEmpty(DependentName))
                {                    
                    emp.EmployeeDependents.Add(new Dependent() { DependentName = DependentName });
                }
            }
            catch (Exception ex)
            {
                status = ex.Message;
            }

            return Json(status, JsonRequestBehavior.AllowGet);
        }

        //GET: To get all the dependant values
        public JsonResult GetAllDependents()
        {            
            return Json(emp.EmployeeDependents, JsonRequestBehavior.AllowGet);
        }

        //To reset the page
        public ActionResult Reset()
        {           
            emp.EmployeeDependents.Clear();
            emp.EmployeeName = "";

            return View("Index");
        }

        //POST: To calculate and post the deduction values for the employees
        [HttpPost]
        public ActionResult CalculateEmployeeDeduction(Employee emp1)
        {
            emp.EmployeeName = emp1.EmployeeName;
            Deduction dec = Calculate();

            TempData["Deductions"] = dec;
            TempData["Employee"] = emp.EmployeeName;
            
            emp.EmployeeDependents.Clear();
            emp.EmployeeName = "";

            return RedirectToAction("Index", "Deduction");
        }

        //Calculate the deduction values for the Employees 
        public Deduction Calculate()
        {
            Deduction dec = new Deduction();
            DeductionCalculation empDedCal = new DeductionCalculation();

            dec.TotalGrossSalary = EmployeeConstant.employeeNoOfPayChecks * EmployeeConstant.employeePayCheckValue;            

            dec.TotalEmployeeDeduction = empDedCal.CalculateEmployeeDeduction(emp.EmployeeName);
            
            if (emp.EmployeeDependents.Count > 0)                
                dec.TotalDependentDeduction = empDedCal.CalculateDependentDeduction(emp.EmployeeDependents);

            dec.TotalNetSalary = dec.TotalGrossSalary - dec.TotalDependentDeduction - dec.TotalEmployeeDeduction;

            return dec;

        }                
    }
}
