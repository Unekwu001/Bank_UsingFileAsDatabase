using Bank_UsingFileAsDatabase.Interfaces.Customer_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_UsingFileAsDatabase.Models.Customer_Model;
using Bank_UsingFileAsDatabase.Interfaces.Account_Interfaces;

namespace Bank_UsingFileAsDatabase.Implementations.Account_Implementation
{
    internal class DashBoard : IDashBoard

    {
        private readonly ICreateAccount _createAcc;
        private readonly IDeposit _deposit;
        private readonly IWithdraw _withdraw;
        private readonly ITransfer _transfer;
        private readonly ICheckBalance _chekBal;
        private readonly ILogOut _logOut;
        public DashBoard(ICreateAccount createAcc, IDeposit deposit, IWithdraw withdraw, ITransfer transfer, ICheckBalance chekBal, ILogOut logOut)
        {
            _createAcc = createAcc;
            _deposit = deposit;
            _withdraw = withdraw;
            _transfer = transfer;
            _chekBal = chekBal;
            _logOut = logOut;
        }





        public void MyDashBoard(Customer LoggedInCustomer)
        {


            Console.WriteLine($"---{LoggedInCustomer.Fullname}'s--DASHBOARD------\n");
            Console.WriteLine($"Welcome, dear {LoggedInCustomer.Fullname} .\nWhat would you like to do today ?\n");
            Console.WriteLine(">Press 1 Create Account");
            Console.WriteLine(">Press 2 to Deposit");
            Console.WriteLine(">Press 3 to Withdraw");
            Console.WriteLine(">Press 4 Transfer");
            Console.WriteLine("Press 5 to get balance");
            Console.WriteLine("Press 6 to get your Statement");
            Console.WriteLine("Press 7 to Logout\n\n");
            Console.Write("Select an option: ");


            string mychoice;
            bool isValidChoice = false;

            do
            {
                mychoice = Console.ReadLine();

                if (mychoice == "1")
                {
                    _createAcc.CreateNewAccount(LoggedInCustomer);
                    MyDashBoard(LoggedInCustomer);

                    isValidChoice = true;
                }
                else if (mychoice == "2")
                {
                    _deposit.DepositMoney(LoggedInCustomer);
                    MyDashBoard(LoggedInCustomer);
                    isValidChoice = true;
                }
                else if (mychoice == "3")
                {
                    _withdraw.WithdrawMoney(LoggedInCustomer);
                    MyDashBoard(LoggedInCustomer);
                    isValidChoice = true;
                }
                else if (mychoice == "4")
                {
                    _transfer.TransferMoney(LoggedInCustomer);
                    MyDashBoard(LoggedInCustomer);
                    isValidChoice = true;
                }
                else if (mychoice == "5")
                {
                    _chekBal.CheckAccountBalance(LoggedInCustomer);

                    isValidChoice = true;
                }
                else if (mychoice == "6")
                {
                    //_myAccService.PrintAccountStatement();

                    isValidChoice = true;
                }

                else if (mychoice == "7")
                {
                    _logOut.LogMeOut(LoggedInCustomer);

                    isValidChoice = true;
                }

            } while (isValidChoice);
        }
    }
}
