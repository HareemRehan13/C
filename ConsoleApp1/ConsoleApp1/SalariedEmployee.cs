using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class SalariedEmployee:Employee
    {
        public double weeklySalary;
        //Constructor
        public SalariedEmployee(double weeklySalary)
        {
            this.weeklySalary = weeklySalary;
        }
        //Method
        public override double earnings()
        {
            return weeklySalary;
        }
    }
}
