using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Employee
    {
      private string  firstName;
        private string lastName;
        private string CNIC;
        //Set Methods
        public void SetfirstName(string a)
        {
            firstName = a;
        }
        public void SetlasttName(string ab)
        {
            lastName = ab;
        }
        public void SetCNIC(string abc)
        {
            CNIC = abc;
        }
        //Get Methods
        public string Getfirstname()
        {
            return firstName;
        }
        public string Getlastname()
        {
            return lastName;
        }
        public string GetCNIC()
        {
            return CNIC;
        }
        //Constructor
        public Employee(string firstName, string lastName, string CNIC)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        this.CNIC = CNIC;   
        }
        //Method
      public double earnings()
        {
            return 0.00;
        }
    }
}
