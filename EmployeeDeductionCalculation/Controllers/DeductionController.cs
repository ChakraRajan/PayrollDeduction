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
        // GET: To get the deduction details
        public ActionResult Index()
        {
            Deduction data = TempData["Deductions"] as Deduction;
            
            return View(data);
        }       
    }
}
