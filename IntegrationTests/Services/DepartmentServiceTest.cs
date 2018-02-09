using Company.BusinessLayer.Services;
using Company.Data;
using Company.Data.Entities;
using Company.Data.Exceptions;
using NUnit.Framework;

namespace IntegrationTests.Services
{
    [TestFixture]
    [Isolated]
    public class DepartmentServiceTest
    {
        /// <summary>
        /// Integration test for department creation functionality
        /// </summary>
        [Test]
        public void CanCreateDepartment()
        {
            var deptService = GetDepartmentServiceInstance();

            var deptName = "FirstDepartment";
            var department = deptService.CreateDepartment(deptName);

            Assert.AreEqual(department.Name, deptName);
            Assert.NotZero(department.Id);
        }

        /// <summary>
        /// Integration test for adding a single employee to the department
        /// </summary>
        [Test]
        public void CanAddEmployeeToDepartment()
        {
            var deptService = GetDepartmentServiceInstance();
            Department department = CreateDepartment(deptService, "FirstDepartment");

            var employee = Employee.Create("FName", "LName", "fname.lname@fdept.com");

            var savedEmployee = deptService.AddEmployee(department, employee);

            Assert.AreEqual(1, department.Employees.Count);
            Assert.NotZero(savedEmployee.Id);
        }

        /// <summary>
        /// Integration test to check the SQL exception for Unique constraint for department name
        /// </summary>
        [Test]
        public void CannotCreateDepartmentHavingSameName()
        {
            var deptService = GetDepartmentServiceInstance();
            var department1 = CreateDepartment(deptService, "FirstDepartment");

            // Asserts the exceptions raised by Entity Framework / E-SQL queries 
            // while saving department having same name
            var ex = Assert.Throws<System.Data.Entity.Infrastructure.DbUpdateException>(() => {
                var department2 = CreateDepartment(deptService, "FirstDepartment");
            });
            Assert.That(ex.StackTrace.Contains("SaveChanges"));
        }

        /// <summary>
        /// Integration test for testing the business rule
        /// "Employee cannot be added to the same department multiple times"
        /// </summary>
        [Test]
        public void CannotAddSameEmployeeMultipleTimes()
        {
            var deptService = GetDepartmentServiceInstance();
            Department department = CreateDepartment(deptService, "FirstDepartment");

            var employee = Employee.Create("FName", "LName", "fname.lname@fdept.com");
            var savedEmployee1 = deptService.AddEmployee(department, employee);

            // Asserts the custom exceptions raised by our code
            var ex = Assert.Throws<EmployeeExistsException>(() => deptService.AddEmployee(department, savedEmployee1));
            Assert.That(ex.Message, Is.EqualTo("Employee already exist in department"));
        }
        
        private static Department CreateDepartment(DepartmentService deptService, string deptName)
        {
            var department = deptService.CreateDepartment(deptName);
            return department;
        }

        private static DepartmentService GetDepartmentServiceInstance()
        {
            var context = new CompanyDBContext();
            var deptService = new DepartmentService(context);
            return deptService;
        }
    }
}
