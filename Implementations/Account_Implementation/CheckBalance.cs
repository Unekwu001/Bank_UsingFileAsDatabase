using Bank_UsingFileAsDatabase.Models.Account_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_UsingFileAsDatabase.Models.Customer_Model;
using Bank_UsingFileAsDatabase.Interfaces.Account_Interfaces;

namespace Bank_UsingFileAsDatabase.Implementations.Account_Implementation
{
	internal class CheckBalance : accHelp, ICheckBalance
	{
		public void CheckAccountBalance(Customer loggedInCustomer)
		{
			List<Account> accounts = ReadAccountsFromFile("Accounts.txt");
			List<Account> loggedInUserAccounts = accounts.Where(account => account.Customerid == loggedInCustomer.CustomerId).ToList();

			string AccountToCheckBalance;
			Console.Clear();
			ShowAllAccount(loggedInCustomer);
			Console.WriteLine("----------Check Balance-----------");

			Console.Write("To check your Balance, Enter an account number Here:>> ");
			AccountToCheckBalance = Console.ReadLine();

			Account? accountToseeBalance = accounts.FirstOrDefault(account => account.AccountNumber == AccountToCheckBalance);
			if (accountToseeBalance != null)
			{
				Console.WriteLine($" The account balance for account Number {AccountToCheckBalance} is {accountToseeBalance.Balance}");
			}
			else
			{
				Console.Clear();
				Console.WriteLine("\n\nAn Error Occured!, Please try again.");
			}

			// Update the Account.txt file with the new objects
			using (StreamWriter writer = new StreamWriter("Accounts.txt"))
			{
				foreach (var account in accounts)
				{
					writer.WriteLine($"| {account.Customerid,-12} | {account.Fullname,-12} | {account.AccountNumber,-12} | {account.AccountType,-8} | {account.Balance} |");
				}
			}
		}

	}
}
