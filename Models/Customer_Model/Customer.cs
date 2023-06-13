using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_UsingFileAsDatabase.Models.Customer_Model
{
    public class Customer
    {
        public Customer(string customerId, string fullname, string email, string password)
        {
            CustomerId = customerId;
            Fullname = fullname;
            Email = email;
            Password = password;
        }

        public string CustomerId { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }




    }
}
