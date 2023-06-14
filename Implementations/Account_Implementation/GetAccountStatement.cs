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
	internal class GetAccountStatement : accHelp, IGetAccountStatement
	{
		public void GetMyAccountStatement(Customer loggedInCustomer)
		{
			List<AccountStatement> AllStatements = ReadAccountStatementFile("AccountStatements.txt");

			List<AccountStatement> loggedInUserAccounts = AllStatements.Where(statement => statement.Id == loggedInCustomer.CustomerId).ToList();

			ShowAllAccount(loggedInCustomer);

			Console.Write("To get your Statement, enter an Account Number >> :");
			string? accEntered = Console.ReadLine();


			List<AccountStatement>  accountToGetStatement = loggedInUserAccounts.Where(account => account.Acc_Involved == accEntered).ToList();

			if (accountToGetStatement is null || !int.TryParse(accEntered, out _))
			{
				Console.Clear();
				Console.WriteLine("The account entered does not exist!\nPlease enter a valid account number>>");

			}

			else if (accountToGetStatement != null)
			{
				Console.Clear();
				string printAll = "";
				for (int i = 0; i < accountToGetStatement.Count; i++)
				{
					AccountStatement statement = accountToGetStatement[i];

					if (i == 0)
					{ 
						Console.WriteLine($"-----------------------Account Statement for: {statement.Name}----------------------");
						Console.WriteLine($"-----------------------Account Number: {statement.Acc_Involved}---------------------");
						Console.WriteLine($"|------DATE--------------|----------Description------------|--------Amount(NAIRA)-----|--------Balance-----------|");
						      printAll += $"|  {statement.Date,-10}  |   {statement.Description,-16}   |  {statement.Amount,-10}  |  {statement.Balance,-10} |\n";
					}
					else
					{
						printAll += $"|  {statement.Date}  |   {statement.Description}   |  {statement.Amount}  |  {statement.Balance} |\n";
					}		
				}
				Console.WriteLine(printAll);				
			}
			Console.ReadKey();
		}
	}
}
