using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using EmployeeDeductionCalculation.Controllers;
using System.Web.Mvc;

namespace EmployeeDeductionCalculation.Tests.Controllers
{
    /// <summary>
    /// Summary description for EmployeeControllerTest
    /// </summary>
    [TestClass]
    public class EmployeeControllerTest
    {
        public EmployeeControllerTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestIndexView()
        {
            var employeeController = new EmployeeController();

            var result = employeeController.Index() as ViewResult;

            Assert.IsNotNull(result.Model);
            
        }

        [TestMethod]
        public void TestResetView()
        {
            var employeeController = new EmployeeController();

            var result = employeeController.Reset() as ViewResult;

            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
