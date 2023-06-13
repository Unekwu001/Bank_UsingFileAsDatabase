using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;
using Bank_UsingFileAsDatabase.Interfaces.Account_Interfaces;
using Bank_UsingFileAsDatabase.Interfaces.Customer_Interfaces;
using Bank_UsingFileAsDatabase.Models.Customer_Model;


namespace Bank_UsingFileAsDatabase.Implementations.Customer_Implementation
{
    internal class Login : regHelp, ILogin
    {
        private IDashBoard _dash;
        public Login(IDashBoard dash) 
        { 
            _dash = dash;
        }





		public void LoginCustomer()
        {
            List<Customer> customers = ReadCustomersFromFile("Customers.txt");
            string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            string passwordPattern = @"^(?=.*[a-zA-Z0-9])(?=.*[@#$%^&+=])(?=.{6,})";
            string? myemail;
            string? mypassword;
            

            Console.WriteLine("------Welcome to your Login portal-------");
            do
            {
                Console.Write("Enter your email. (E.g., john@gmail.com):>>> ");
                myemail = Console.ReadLine();
            } while (!Regex.IsMatch(myemail, emailPattern));

            do
            {
				Console.WriteLine("password should not be less than 6 characters and should contain a special character E.G @ ,#,* ");
				Console.Write("Enter your password :>>> ");
                mypassword = Console.ReadLine();
            } while (!Regex.IsMatch(mypassword, passwordPattern));


			

			Customer? loggedInUser = customers.FirstOrDefault(c => c.Email == myemail && c.Password == mypassword);
			
            if (loggedInUser != null)
			{
				Console.Clear();
				Console.WriteLine("Successfully Logged in!");
                _dash.MyDashBoard(loggedInUser);
			}
			else
			{
				Console.WriteLine("\n\nInvalid email or password.");
				Console.WriteLine("Please try again or register a new account.");
			}


		}
    }
}
