using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_UsingFileAsDatabase.Models.Customer_Model;
using Bank_UsingFileAsDatabase.Interfaces.Customer_Interfaces;

namespace Bank_UsingFileAsDatabase.Implementations.Customer_Implementation
{
	internal class LogOut : ILogOut
	{


		//1st Overload

		public void LogMeOut(Customer loggedInCustomer)
		{
			Console.Clear();
			loggedInCustomer = null;
			Console.WriteLine("Logged out successfully. Thank you for banking with us!");
		}




		//2nd Overload
		public void LogMeOut()
		{
			Console.Clear();
			Console.WriteLine("Logged out successfully. Thank you for banking with us!");
			Environment.Exit(0);	
		}
	}
}
