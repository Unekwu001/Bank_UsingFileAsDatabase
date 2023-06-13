using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_UsingFileAsDatabase.Interfaces.Customer_Interfaces;
using Bank_UsingFileAsDatabase.Models.Customer_Model;

namespace Bank_UsingFileAsDatabase.Implementations.Customer_Implementation
{
    public class Register : regHelp, IRegister
    {
        public void RegisterCustomer()
        {
            var id = CustomerId();
            var name = CustomerName();
            var email = CustomerEmail();
            var pwd = CustomerPassword();

            //Creating a customer
            Customer customer = new Customer(id, name, email, pwd);

            //Inserting customer details to file
            using (StreamWriter writer = new StreamWriter("Customers.txt", true))
            {
                writer.WriteLine($"|  {customer.CustomerId,-12}   |      {customer.Fullname,-16}    | {customer.Email,-18}   |  {customer.Password,-18}  | \n\n");
            }
            Console.WriteLine($" Customer {name} has been added to File.");
        }
    }
}
