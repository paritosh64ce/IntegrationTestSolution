using Company.Data;
using Company.Data.Entities;

namespace Company.BusinessLayer.Services
{
    public class DepartmentService
    {
        private CompanyDBContext context;

        public DepartmentService(CompanyDBContext context)
        {
            this.context = context;
        }

        public Department CreateDepartment(string name, string description = "")
        {
            var department = Department.Create(name, description);
            context.Departments.Add(department);
            context.SaveChanges();

            return department;
        }

        public Employee AddEmployee(Department dept, Employee emp)
        {
            dept.AddEmployee(emp);
            context.SaveChanges();

            return emp;
        }
    }
}