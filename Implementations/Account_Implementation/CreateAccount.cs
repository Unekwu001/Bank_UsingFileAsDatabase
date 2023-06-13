using Bank_UsingFileAsDatabase.Models.Customer_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Bank_UsingFileAsDatabase.Models.Account_Model;
using System.Xml.Linq;
using Bank_UsingFileAsDatabase.Interfaces.Account_Interfaces;
using System.Security.AccessControl;

namespace Bank_UsingFileAsDatabase.Implementations.Account_Implementation
{
	internal class CreateAccount : ICreateAccount
	{
		
		public string AcNo { get; set; }
		public decimal Bal { set; get; }
		public string AcType { set; get; }
		public CreateAccount()
		{
			AcNo = "";
			Bal = 0;
			AcType = "";
			 
		}
	 
		



		public void CreateNewAccount(Customer loggedInCustomer)
		{
			Console.Clear();
			GenerateAnotherAccountNo();
			selectAccType();			
			SaveCreatedAccDetails();
		 



			void selectAccType()
			{

				Console.WriteLine(" Please Enter your desired account type\n");
				Console.WriteLine(">  Press 1 for savings account\n>  Press 2 for current account  ");
				string? input = Console.ReadLine();



				if (input == "" || input is null || !int.TryParse(input, out _))
				{
					Console.Clear();
					Console.WriteLine("You have entered an incorrect command. Please Retry");
					selectAccType();
				 
				}
				else if (input == "1")
				{
					AcType = "savings";
					Console.WriteLine("You need to deposit at least 1000 naira to open such an account");
					Console.Write("Please enter an amount greater or equal to 1000 naira: ");

					string enteredAmount;
					enteredAmount = Console.ReadLine();

					if (enteredAmount is null || enteredAmount == " " || !int.TryParse(enteredAmount, out _) || int.Parse(enteredAmount) < 1000)
					{
						Console.WriteLine($"Invalid amount!. You need to enter an amount greater then 1000 naira. ");
						Console.WriteLine($"Process Restarted !");
						selectAccType();
					}
					else if (int.Parse(enteredAmount) > 999)
					{
						decimal cleanAmount = decimal.Parse(enteredAmount);
						Bal = cleanAmount;
						Console.WriteLine($"You have successfully added {cleanAmount} naira");

						
						AccountStatement myAccStatement = new AccountStatement(loggedInCustomer.CustomerId, loggedInCustomer.Fullname, $"Account {AcNo} of type {AcType} was created", enteredAmount , Bal,DateTime.Now);

						using (StreamWriter writer = new StreamWriter("AccountStatements.txt", true))
						{
							writer.WriteLine($"| {myAccStatement.Id}   |   {myAccStatement.Name}   |   {myAccStatement.Description}   |  {myAccStatement.Amount}   |  {myAccStatement.Balance}  |  {myAccStatement.Date} |\n\n");
						}

					}
				}
				else if (input == "2")
				{
					AcType = "current";
					Bal = 0m;
					Console.WriteLine($"You have successfully created a new account.\n ");


					AccountStatement myAccStatement = new AccountStatement(loggedInCustomer.CustomerId, loggedInCustomer.Fullname, $"Account {AcNo} of type {AcType} was created", "0", Bal, DateTime.Now);

					using (StreamWriter writer = new StreamWriter("AccountStatements.txt", true))
					{
						writer.WriteLine($"| {myAccStatement.Id}   |   {myAccStatement.Name}   |   {myAccStatement.Description}   |  {myAccStatement.Amount}   |  {myAccStatement.Balance}  |  {myAccStatement.Date} |\n\n");
					}


				}

			}




			void GenerateAnotherAccountNo()
			{

				Random random = new Random();
				var i = random.Next(1000000000, 2099999999); //tells the range of random numbers you want to generate.
				AcNo = i.ToString();
				Console.WriteLine($"Here is your generated Account Number!>> {AcNo}");
			}
			 

			void SaveCreatedAccDetails()
			{

				Account myAccount = new Account(loggedInCustomer.CustomerId,loggedInCustomer.Fullname, AcNo, AcType, Bal);

				using (StreamWriter writer = new StreamWriter("Accounts.txt", true))
				{
					writer.WriteLine($"| {myAccount.Customerid}   |   {myAccount.Fullname}   |   {myAccount.AccountNumber}   |  {myAccount.AccountType}   |  {myAccount.Balance}  | \n\n");
				}
				Console.WriteLine($" Congratulations {loggedInCustomer.Fullname}.\n Your newly created Account has been added to File.");
			}
		}
	}
}
