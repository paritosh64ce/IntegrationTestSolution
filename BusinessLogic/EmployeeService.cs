using System;
using Data;
using Data.Entities;

namespace BusinessLogic
{
    public class EmployeeService
    {
        private CompanyDBContext context;

        public EmployeeService(CompanyDBContext context)
        {
            this.context = context;
        }

        public Employee GetEmployeeById(string emailId)
        {
            throw new NotImplementedException();
        }

        public Employee CreateEmployee(string firstName, string lastName, string email)
        {
            var employee = new Employee { FirstName = firstName, LastName = lastName, Email = email };
            context.Employees.Add(employee);
            context.SaveChanges();

            return employee;
        }
    }
}