namespace Company.Data.Entities
{
    public class Employee
    {
        public long Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public decimal Salary { get; set; }

        private Employee() { }

        public void IncreaseSalary(decimal increment)
        {
            this.Salary += increment;
        }

        public static Employee Create(string fName, string lName, string email, decimal salary = 0)
        {
            return new Employee
            {
                FirstName = fName,
                LastName = lName,
                Email = email,
                Salary = salary
            };
        }
    }
}
