using Bank_UsingFileAsDatabase.Implementations.Customer_Implementation;
using Bank_UsingFileAsDatabase.Interfaces.Customer_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_UsingFileAsDatabase
{
	internal class HomePage
	{
		public IRegister _reg;
		public ILogin _login;
		public ILogOut _logout;
		public HomePage(IRegister reg, ILogin log,ILogOut logOut)
		{
			_reg = reg;
			_login = log;
			_logout = logOut;

		}



		public void RunMyHomePage()
		{
			string choice;

			do
			{

				Console.WriteLine("Welcome to Shazam Bank\n\n\n>Press 1 To Register\n\n>Press 2 To login\n\n>Press 3 To Exit.\n\n ");
				choice = Console.ReadLine();

				if (choice == "1")
				{
					_reg.RegisterCustomer();  		 
				}
				if (choice == "2")
				{

					Console.Clear();
					_login.LoginCustomer();
				}
				if (choice == "3")
				{
					_logout.LogMeOut();
					Console.WriteLine("Thanks for Banking with us");
					Environment.Exit(0);
				}

			}
			while (!int.TryParse(choice, out _) || int.Parse(choice) != 1 || int.Parse(choice) != 2 || int.Parse(choice) != 3);
		}
	}
}
