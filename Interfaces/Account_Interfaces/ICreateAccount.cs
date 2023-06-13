using Bank_UsingFileAsDatabase.Models.Customer_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_UsingFileAsDatabase.Interfaces.Account_Interfaces
{
	public interface ICreateAccount
	{
		void CreateNewAccount(Customer loggedInCustomer);
	}
}
