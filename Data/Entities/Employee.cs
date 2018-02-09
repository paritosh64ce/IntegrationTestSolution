namespace Company.Data.Entities
{
    public class Employee
    {
        public long Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }

        private Employee() { }

        public static Employee Create(string fName, string lName, string email)
        {
            return new Employee
            {
                FirstName = fName,
                LastName = lName,
                Email = email
            };
        }
    }
}
