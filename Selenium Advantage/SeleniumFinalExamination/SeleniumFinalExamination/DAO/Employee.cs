using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFinalExamination.DAO
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string Email { get; set; }
        public string Salary { get; set; }
        public string Department { get; set; }
        public Employee(string firstname, string lastname, string age, string email, string salary, string department)
        {
            FirstName = firstname;
            LastName = lastname;
            Age = age;
            Email = email;
            Salary = salary;
            Department = department;

        }
    }
}
