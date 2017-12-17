using System;
using Data;
using Data.Entities;

namespace BusinessLogic
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
            var department = new Department { Name = name, Description = description };
            context.Departments.Add(department);
            context.SaveChanges();

            return department;
        }
    }
}