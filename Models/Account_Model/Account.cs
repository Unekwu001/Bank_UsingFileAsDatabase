using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_UsingFileAsDatabase.Models.Account_Model
{
	internal class Account
	{
		public string Fullname { get; set; }
		public string Customerid { get; set; }
		public string AccountNumber { get; set; }
		public decimal Balance { get; set; }
		public string AccountType { get; set; }

		public Account(string customerid, string fullname, string accountNumber, string accountType, decimal balance)
		{
			Fullname = fullname;
			Customerid = customerid;
			AccountNumber = accountNumber;
			AccountType = accountType;
			Balance = balance;
		}
	}
}
