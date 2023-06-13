using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_UsingFileAsDatabase.Models.Customer_Model;

namespace Bank_UsingFileAsDatabase.Interfaces.Customer_Interfaces
{
	internal interface ILogOut
	{
		void LogMeOut(Customer loggedInCustomer);
		void LogMeOut();
	}
}
