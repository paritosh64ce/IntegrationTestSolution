using System.Collections.Generic;

namespace Data.Entities
{
    public class Department
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Employee> Emplopyees { get; set; }
    }
}
