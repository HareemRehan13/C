using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class HourlyEmployee:Employee
    {
        public double wage;
        public double hours;
        //Constructor
        public HourlyEmployee(double wage, double hours)
        {
            this.wage = wage;
            this.hours = hours;
        }
        //Method
        public override double earnings()
        {
            if (hours >= 40){
                return wage * hours;
            }

           else
            {
                return wage;
            }
        }
    }
}
