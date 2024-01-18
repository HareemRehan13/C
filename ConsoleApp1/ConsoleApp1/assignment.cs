using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //Ques 1
    internal class BankAccount
    {
        public double balance;
        public double monthlyservicecharges;
        public int numberOfDeposits;
        public int numberofwithdrawls;
        //Constructor
        public BankAccount(double balance, double monthlyservicecharges)
        {
            this.balance = balance;
            this.monthlyservicecharges = monthlyservicecharges;
            numberOfDeposits = 0;
            numberofwithdrawls = 0;
        }
        //Deposit Method
        public void Deposit(double depositamount)
        {
            balance += depositamount;
            numberOfDeposits++;
        }
        //Withdrawl Method
        public void Withdrawl(double withdrawlamount) {
            balance -= withdrawlamount;
            numberofwithdrawls++;
        }
        //MontlyProcess Method
        public void MonthlyProcess()
        {
            balance -= monthlyservicecharges;
        }
        //Get Methods
        public double GetBalance() { 
        return balance;
        }
        public double GetNumberOfDeposits()
        {
            return numberOfDeposits;    
        }
        public int GetNumberOfWithdrawls()
        {
            return numberofwithdrawls;
        }
       
    }
    // Ques 2
    internal class Hotel
    {
        public string hotel_name;
        public string address;
        public string tax_number;
        //Constructor
        public Hotel(string hotel_name, string address , string tax_number )
        {
            this.hotel_name = hotel_name;
            this.address = address; 
            this.tax_number= tax_number;

        }
        //Methods
        public void SetHotelName(string name)
        {
            hotel_name = name;
        }
        public void SetAddress(string addr)
        {
            address = addr;
        }
        public void SetTaxnumber(string taxnumber)
        {
            tax_number = taxnumber; 
        }
        //Get Methods
        public string GetHotelName()
        {
            return  hotel_name;
        }
        public string GetAddress()
        {
            return address;
        }
        public string GetTaxNumber()
        {
            return tax_number;
        }

    }
    internal class GuestHouse:Hotel
    {
        public int permit_no;
       public int contact_person;
        public int number_of_rooms;
        public GuestHouse(int permit_no, int contact_person, int number_of_rooms):base("abc","abc street", "0876")
        {
            this.permit_no = permit_no;
            this.contact_person = contact_person;
            this.number_of_rooms = number_of_rooms;
        }
        //Get Methods
        public int Getpermit_no()
        {
            return permit_no;
        }
        public int Getcontact_person()
        {
            return contact_person;
        }
        public int Getnumber_of_rooms()
        {
            return number_of_rooms;
        }
    }
        
}
