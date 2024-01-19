using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ques 1
            BankAccount myAccount = new BankAccount(5000.0, 5.0);
            // Deposit 
            myAccount.Deposit(500.0);

            // Withdraw 
            myAccount.Withdrawl(200.0);
            //Monthly Processing
            myAccount.MonthlyProcess();
            Console.WriteLine("Current Balance:" + myAccount.GetBalance());
            Console.WriteLine("Number Of Deposits:" + myAccount.GetNumberOfDeposits());
            Console.WriteLine("NumberOfWithdrawls:" + myAccount.GetNumberOfWithdrawls());


            //Ques 2
            Hotel myHotel = new Hotel("ABC Hotel", "123 street", "07854531");

            Console.WriteLine("Hotel Name:" + myHotel.GetHotelName());
            Console.WriteLine("Address:" + myHotel.GetAddress());
            Console.WriteLine("Tax Number:" + myHotel.GetTaxNumber());


            GuestHouse obj = new GuestHouse(90786, 56887, 976);

            Console.WriteLine(obj.Getpermit_no());
            Console.WriteLine(obj.Getcontact_person());
            Console.WriteLine(obj.Getnumber_of_rooms());
            Console.ReadLine();
        }     

    }
}
