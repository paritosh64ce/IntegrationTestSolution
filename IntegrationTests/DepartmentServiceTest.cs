using BusinessLogic;
using Data;
using NUnit.Framework;
using System;

namespace IntegrationTests
{
    [TestFixture]
    public class DepartmentServiceTest
    {
        [Test]
        public void CanCreateDepartment()
        {
            var context = new CompanyDBContext();
            var deptService = new DepartmentService(context);

            var deptName = "FistDepartment";
            var department = deptService.CreateDepartment(deptName);

            Assert.AreEqual(department.Name, deptName);
            Assert.NotZero(department.Id);
        }
    }
}
