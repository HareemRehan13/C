using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class HourlyEmployee:Employee
    {
        private double wage;
        private double hours;
        //Get Method
        public void Setwage(double c)
        {
         
                if (wage == -c)
                {
                    Console.WriteLine("wage can't sets to negative value.");
                }
                else
                {
                wage = c;
                }

        }
        public void Sethours(double d)
        {
           
            if (d <=0)
            {
                Console.WriteLine("hours can't sets to negative value.");
            }
            else
            {
               hours = d;
            }
        }
        
        //Constructor
        public HourlyEmployee(double wage, double hours) : base("hareem", "rehan", "567447")
        {
            this.wage = wage;
            this.hours = hours;
        }
        //Method
        public double earnings()
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
