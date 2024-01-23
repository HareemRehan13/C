using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class SalariedEmployee:Employee
    {
        private double weeklySalary;
        //Set Method
        public void SetweeklySalary(double b)
        {
            if (b<=0)
            {
                Console.WriteLine("weeklySalary can't sets to negative value.");
            }
            else { 
                weeklySalary = b;
            }
           
        }
       
        //Constructor
        public SalariedEmployee(double weeklySalary):base("hareem","rehan","567447")
        {
            this.weeklySalary = weeklySalary;
        }
        //Method
        public double earnings()
        {
            return weeklySalary;
        }
    }
}
