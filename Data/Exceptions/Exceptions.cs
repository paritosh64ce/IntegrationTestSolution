using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Data.Exceptions
{
    public class EmployeeExistsException: Exception
    {
        public EmployeeExistsException(string msg) : base(msg) { }
    }
}
