using Bank_UsingFileAsDatabase.Models.Customer_Model;
using Bank_UsingFileAsDatabase.Implementations.Customer_Implementation;

namespace Bank_UsingFileAsDatabase.Interfaces.Account_Interfaces
{
    internal interface IDashBoard
    {
        void MyDashBoard(Customer LoggedInCustomer);
    }
}