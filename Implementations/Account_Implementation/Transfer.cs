using Bank_UsingFileAsDatabase.Implementations.Customer_Implementation;
using Bank_UsingFileAsDatabase.Interfaces.Account_Interfaces;
using Bank_UsingFileAsDatabase.Models.Account_Model;
using Bank_UsingFileAsDatabase.Models.Customer_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_UsingFileAsDatabase.Implementations.Account_Implementation
{
	internal class Transfer : accHelp, ITransfer
	{


		//transfer fields
		private string? AccountToTransferTo { get; set; }
		private string? AccountToTransferFrom { get; set; }
		private decimal CleanAmountToTransfer { get; set; }


		public void TransferMoney(Customer loggedInCustomer)
		{
			Console.Clear();

			List<Account> accounts = ReadAccountsFromFile("Accounts.txt");
			List<Account> loggedInUserAccounts = accounts.Where(account => account.Customerid == loggedInCustomer.CustomerId).ToList();

			ShowAllAccount(loggedInCustomer);
			Console.WriteLine("----------Transfers-----------");
			Console.Write("\nEnter the account number you are  TRANSFERING FROM:>> ");

			AccountToTransferFrom = Console.ReadLine();

			Console.Write("Enter the account you want to TRANSFER TO:>> ");
			AccountToTransferTo = Console.ReadLine();

			Console.Write("Enter the amount you want to transfer:>> ");
			string? AmountToTransfer = Console.ReadLine();

			CleanAmountToTransfer = decimal.Parse(AmountToTransfer);

			Account? giver = loggedInUserAccounts.FirstOrDefault(account => account.AccountNumber == AccountToTransferFrom);
			Account? receiver = loggedInUserAccounts.FirstOrDefault(account => account.AccountNumber == AccountToTransferTo);



			if (giver != null && receiver != null && giver.AccountType == "savings" && giver.Balance > CleanAmountToTransfer + 1000)
			{
				giver.Balance -= CleanAmountToTransfer;
				receiver.Balance += CleanAmountToTransfer;
				Console.WriteLine($"{CleanAmountToTransfer} has been Sent to {AccountToTransferTo} successfully!");

				//
				AccountStatement myAccStatement = new AccountStatement(loggedInCustomer.CustomerId, loggedInCustomer.Fullname,giver.AccountNumber, $"You Transfered {CleanAmountToTransfer} to {receiver.AccountNumber}", $"{CleanAmountToTransfer}", giver.Balance, DateTime.Now);

				using (StreamWriter writer = new StreamWriter("AccountStatements.txt", true))
				{
					writer.WriteLine($"| {myAccStatement.Id}   |   {myAccStatement.Name}   |  {myAccStatement.Acc_Involved}  | {myAccStatement.Description}   |  {myAccStatement.Amount}   |  {myAccStatement.Balance}  |  {myAccStatement.Date} |\n\n");
				}
				
				//
				AccountStatement myAccStatement2 = new AccountStatement(loggedInCustomer.CustomerId, loggedInCustomer.Fullname,receiver.AccountNumber, $"You Received {CleanAmountToTransfer} from {giver.AccountNumber}", $"{CleanAmountToTransfer}", receiver.Balance, DateTime.Now);

				using (StreamWriter writer = new StreamWriter("AccountStatements.txt", true))
				{
					writer.WriteLine($"| {myAccStatement2.Id}   |   {myAccStatement2.Name}   | {myAccStatement2.Acc_Involved} |  {myAccStatement2.Description}   |  {myAccStatement2.Amount}   |  {myAccStatement2.Balance}  |  {myAccStatement2.Date} |\n\n");
				}


			}
			else if (giver != null && receiver != null && giver.AccountType == "current" && giver.Balance > CleanAmountToTransfer)
			{
				giver.Balance -= CleanAmountToTransfer;
				receiver.Balance += CleanAmountToTransfer;
				Console.WriteLine($"{CleanAmountToTransfer} has been Sent to {AccountToTransferTo} successfully!");

				//
				AccountStatement myAccStatement = new AccountStatement(loggedInCustomer.CustomerId, loggedInCustomer.Fullname,giver.AccountNumber, $"You Transfered {CleanAmountToTransfer} to {receiver.AccountNumber}", $"{CleanAmountToTransfer}", giver.Balance, DateTime.Now);

				using (StreamWriter writer = new StreamWriter("AccountStatements.txt", true))
				{
					writer.WriteLine($"| {myAccStatement.Id}   |   {myAccStatement.Name}   | {myAccStatement.Acc_Involved}  |  {myAccStatement.Description}   |  {myAccStatement.Amount}   |  {myAccStatement.Balance}  |  {myAccStatement.Date} |\n\n");
				}

				//
				AccountStatement myAccStatement2 = new AccountStatement(loggedInCustomer.CustomerId, loggedInCustomer.Fullname,receiver.AccountNumber, $"You Received {CleanAmountToTransfer} from {giver.AccountNumber}", $"{CleanAmountToTransfer}", giver.Balance, DateTime.Now);

				using (StreamWriter writer = new StreamWriter("AccountStatements.txt", true))
				{
					writer.WriteLine($"| {myAccStatement2.Id}   |   {myAccStatement2.Name}   | {myAccStatement2.Acc_Involved} | {myAccStatement2.Description}   |  {myAccStatement2.Amount}   |  {myAccStatement2.Balance}  |  {myAccStatement2.Date} |\n\n");
				}
			}
			else 
			{
				Console.Clear();
				Console.WriteLine($"\n\nError in Transaction!\n\n");
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
