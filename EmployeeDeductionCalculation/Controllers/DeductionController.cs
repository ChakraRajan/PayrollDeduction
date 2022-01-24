using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeDeductionCalculation.Models;

namespace EmployeeDeductionCalculation.Controllers
{
    public class DeductionController : Controller
    {
        // GET: Deduction
        public ActionResult Index()
        {
            Deduction data = TempData["Deductions"] as Deduction;
            //Employee employeeData = TempData["Employee"] as Employee;

            var Employee = TempData["Employee"] as Employee;

            return View(data);
        }       
    }
}
