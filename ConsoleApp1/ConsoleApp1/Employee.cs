using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Employee
    {
      public string  firstName;
        public string lastName;
        public string CNIC;
        //Constructor
        public Employee(string firstName, string lastName, string CNIC)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        this.CNIC = CNIC;   
        }
        //Method
      public virtual double earnings()
        {
            return 0.00;
        }
    }
}
