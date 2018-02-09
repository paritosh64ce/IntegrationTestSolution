using System;
using System.Linq;
using Company.Data;
using Company.Data.Entities;

namespace Company.BusinessLayer.Services
{
    public class EmployeeService
    {
        private CompanyDBContext context;

        public EmployeeService(CompanyDBContext context)
        {
            this.context = context;
        }

        public Employee GetEmployeeByEmailId(string emailId)
        {
            var employee = this.context.Employees.SingleOrDefault(x => x.Email == emailId);
            return employee;
        }

        public Employee CreateEmployee(string firstName, string lastName, string email)
        {
            var employee = Employee.Create(firstName, lastName, email);
            context.Employees.Add(employee);
            context.SaveChanges();

            return employee;
        }

        public void UpdateEmployee(Employee employee)
        {
            context.Entry(employee).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
    }
}