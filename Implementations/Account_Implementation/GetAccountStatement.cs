using Bank_UsingFileAsDatabase.Models.Account_Model;
using Bank_UsingFileAsDatabase.Models.Customer_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_UsingFileAsDatabase.Implementations.Account_Implementation
{
	internal class GetAccountStatement
	{
		public void GetMyAccountStatement(Customer loggedInCustomer)
		{
			List<Account> accounts = ReadAccountStatementFile("AccountStatement.txt");

			List<Account> loggedInUserAccounts = accounts.Where(account => account.Customerid == LoggedInCustomer.CustomerId).ToList();

		}
	}
}
