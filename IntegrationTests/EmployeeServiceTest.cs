using BusinessLogic;
using Data;
using Data.Entities;
using NUnit.Framework;

namespace IntegrationTests
{
    [TestFixture]
    public class EmployeeServiceTest
    {
        [Test]
        public void CanCreateEmployee()
        {
            var context = new CompanyDBContext();
            var employeeService = new EmployeeService(context);

            Employee emp = employeeService.CreateEmployee("Paritosh", "Patel", "paritosh@company.com");
            Assert.Equals(emp.Email, "paritosh@company.com");
            Assert.IsNotEmpty(emp.FirstName);
            Assert.IsNotEmpty(emp.LastName);
            Assert.NotZero(emp.Id);
        }
    }
}
