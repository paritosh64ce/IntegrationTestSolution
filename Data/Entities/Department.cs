using Company.Data.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Company.Data.Entities
{
    public class Department
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public ICollection<Employee> Employees { get; }

        private Department()
        {
            this.Employees = new List<Employee>();
        }

        public static Department Create(string name, string description)
        {
            return new Department
            {
                Name = name,
                Description = description
            };
        }

        public void AddEmployee(Employee employee)
        {
            if (Employees.Any(x => x.Email == employee.Email))
            {
                throw new EmployeeExistsException("Employee already exist in department");
            }
            Employees.Add(employee);
        }
    }
}
