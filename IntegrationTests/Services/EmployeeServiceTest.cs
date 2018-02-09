using Company.BusinessLayer.Services;
using Company.Data;
using Company.Data.Entities;
using NUnit.Framework;
using System;

namespace IntegrationTests.Services
{
    [TestFixture]
    [Isolated]
    public class EmployeeServiceTest
    {
        /// <summary>
        /// Integration test to make sure the entity has been saved successfully
        /// and the saved entity has proper value for the Id
        /// </summary>
        [Test]
        public void CanCreateEmployee()
        {
            var employeeService = GetEmployeeServiceInstance();
            var fName = Guid.NewGuid().ToString();
            var lName = Guid.NewGuid().ToString();
            var email = Guid.NewGuid().ToString();
            var emp = employeeService.CreateEmployee(fName, lName, email);

            Assert.AreEqual(email, emp.Email);
            Assert.AreEqual(fName, emp.FirstName);
            Assert.AreEqual(lName, emp.LastName);
            Assert.NotZero(emp.Id);
        }

        /// <summary>
        /// Integration test to check the SQL exception for Unique constraint for email field
        /// </summary>
        [Test]
        public void EmployeeEmailShouldBeUnique()
        {
            var employeeService = GetEmployeeServiceInstance();
            var email = "Same@email.id";
            var emp1 = employeeService.CreateEmployee("FName1", "LName1", email);
            Assert.NotZero(emp1.Id);

            // Asserts the exceptions raised by Entity Framework / E-SQL queries
            var ex = Assert.Throws<System.Data.Entity.Infrastructure.DbUpdateException>(() => {
                var emp2 = employeeService.CreateEmployee("FName2", "LName2", email);
            });
            Assert.That(ex.StackTrace.Contains("SaveChanges"));
        }

        //[Test]
        //public void UpdateEmployeeShouldWork()
        //{
        //    var empSvc = GetEmployeeServiceInstance();
        //    empSvc.CreateEmployee("FName1", "LName1", "fname.lname@company", 1500);

        //    var emp = empSvc.GetEmployeeByEmailId("fname.lname@company");
        //    //savedEmp.
        //    empSvc.UpdateEmployee(emp);
        //}

        private EmployeeService GetEmployeeServiceInstance()
        {
            var context = new CompanyDBContext();
            return new EmployeeService(context);
        }
    }
}
