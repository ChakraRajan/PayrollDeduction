using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using EmployeeDeductionCalculation.Service;
using EmployeeDeductionCalculation.Models;


namespace EmployeeDeductionCalculation.Tests.Service
{
    /// <summary>
    /// Summary description for ServiceTest
    /// </summary>
    [TestClass]
    public class ServiceTest
    {
        public ServiceTest()
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
        public void TestCalculateEmployeeDeduction()
        {
            var Employee = "Adam";

            var DeductionCalculation = new DeductionCalculation();

            var employeeDeduction = DeductionCalculation.CalculateEmployeeDeduction(Employee);

            var expEmployeeDeduction = 900.00m;

            Assert.AreEqual(employeeDeduction, expEmployeeDeduction);

            Employee = "Don";

            employeeDeduction = DeductionCalculation.CalculateEmployeeDeduction(Employee);

            expEmployeeDeduction = 1000.00m;

            Assert.AreEqual(employeeDeduction, expEmployeeDeduction);

        }

        [TestMethod]
        public void TestDependentDeduction()
        {
            var DeductionCalculation = new DeductionCalculation();

            List<Dependent> dependents = new List<Dependent>();

            dependents.Add(new Dependent { DependentName = "Adam Son" });
            dependents.Add(new Dependent { DependentName = "Adam Wife" });
            dependents.Add(new Dependent { DependentName = "Adam Mom" });

            var dependentDeduction = DeductionCalculation.CalculateDependentDeduction(dependents);

            var expDependentDeduction = 1350.00m;

            Assert.AreEqual(dependentDeduction, expDependentDeduction);

            dependents.Clear();

            dependents.Add(new Dependent { DependentName = "Don Son" });
            dependents.Add(new Dependent { DependentName = "Don Wife" });
            dependents.Add(new Dependent { DependentName = "Don Mom" });

            dependentDeduction = DeductionCalculation.CalculateDependentDeduction(dependents);

            expDependentDeduction = 1500.00m;

            Assert.AreEqual(expDependentDeduction, dependentDeduction);

        }
    }
}

