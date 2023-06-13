using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_UsingFileAsDatabase.Models.Customer_Model;

namespace Bank_UsingFileAsDatabase.Interfaces.Account_Interfaces
{
	internal interface IWithdraw
	{
		void WithdrawMoney(Customer LoggedInCustomer);
	}
}
