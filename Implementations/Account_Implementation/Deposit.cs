using Bank_UsingFileAsDatabase.Models.Account_Model;
using Bank_UsingFileAsDatabase.Models.Customer_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_UsingFileAsDatabase.Interfaces.Account_Interfaces;

namespace Bank_UsingFileAsDatabase.Implementations.Account_Implementation
{
	internal class Deposit : accHelp, IDeposit
	{
		//Deposit fields
		private string? AccountToDepositTo { get; set; }
		private string? AmountToDeposit { get; set; }
		private decimal CleanAmountToDeposit { get;set; }




		public void DepositMoney(Customer LoggedInCustomer)
		{
			Console.Clear();

			ShowAllAccount(LoggedInCustomer);

			Console.Write("Type in the account number you want to send money to.>>");
			AccountToDepositTo = Console.ReadLine();

			Console.Write("Enter the amount you want to send>>>");
			AmountToDeposit = Console.ReadLine().Trim();
			CleanAmountToDeposit = decimal.Parse(AmountToDeposit);

			List<Account> accounts = ReadAccountsFromFile("Accounts.txt");

			List<Account> loggedInUserAccounts = accounts.Where(account => account.Customerid == LoggedInCustomer.CustomerId).ToList();

			Account? accountToUpdate = loggedInUserAccounts.FirstOrDefault(account => account.AccountNumber == AccountToDepositTo);

			if (accountToUpdate is null)
			{
				Console.Clear();
				Console.WriteLine("The account entered does not exist!\nPlease enter a valid account number>>");
			 
			}

			else if (accountToUpdate != null)
			{
				accountToUpdate.Balance += CleanAmountToDeposit;
				Console.WriteLine($"You have successfully deposited {CleanAmountToDeposit} into your account with account number {AccountToDepositTo}");


				AccountStatement myAccStatement = new AccountStatement(LoggedInCustomer.CustomerId, LoggedInCustomer.Fullname, "CREDIT", $"{CleanAmountToDeposit}", accountToUpdate.Balance, DateTime.Now);

				using (StreamWriter writer = new StreamWriter("AccountStatements.txt", true))
				{
					writer.WriteLine($"| {myAccStatement.Id}   |   {myAccStatement.Name}   |   {myAccStatement.Description}   |  {myAccStatement.Amount}   |  {myAccStatement.Balance}  |  {myAccStatement.Date} |\n\n");
				}


			}
			// Update the Account.txt file with the new balance
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
