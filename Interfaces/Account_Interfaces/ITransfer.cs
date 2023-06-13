using Bank_UsingFileAsDatabase.Models.Customer_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_UsingFileAsDatabase.Interfaces.Account_Interfaces
{
	internal interface ITransfer
	{
		void TransferMoney(Customer loggedInCustomer);
	}
}
