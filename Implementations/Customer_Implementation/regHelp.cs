using Bank_UsingFileAsDatabase.Models.Customer_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bank_UsingFileAsDatabase.Implementations.Customer_Implementation
{
    public class regHelp
    {


        public string CustomerId()
        {
            Random random = new Random();
            var cus_id = random.Next(1, 2099999999);
            var cusId = cus_id.ToString();
            return cusId;
        }






        public string CustomerName()
        {
            string namePattern = @"^[A-Z][a-zA-Z]*\s[A-Z][a-zA-Z]*$";
            string fullname;
            do
            {
                Console.WriteLine("Enter your fullname to register \n(Both Should start with a capital Letter E.G John Kehinde)");
                fullname = Console.ReadLine().Trim();

            }
            while (!Regex.IsMatch(fullname, namePattern));
            return fullname;
        }






        public string CustomerEmail()
        {
            string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            string email;
            do //reading email from console
            {
                Console.Clear();
                Console.WriteLine("Please input your email\nYour email should be in the correct format E.G john@gmail.com");
                email = Console.ReadLine();

            }
            while (!Regex.IsMatch(email, emailPattern));
            return email;
        }





        public string CustomerPassword()
        {
            string passwordPattern = @"^(?=.*[a-zA-Z0-9])(?=.*[@#$%^&+=])(?=.{6,})";
            string password;

            do //reading password from console
            {
                Console.Clear();
                Console.WriteLine("Please input your password\nYour password should not be less than 6 characters and should also have a special character E.G '@23Wasme2");
                password = Console.ReadLine();

            }
            while (!Regex.IsMatch(password, passwordPattern));
            return password;
        }

		//------------------------------------------------------------------------------------------------------------------



		public static List<Customer> ReadCustomersFromFile(string filePath)
		{
			List<Customer> customers = new List<Customer>();

			using (StreamReader reader = new StreamReader(filePath))
			{
				string line;
				while ((line = reader.ReadLine()) != null)
				{
					if (!string.IsNullOrWhiteSpace(line))
					{
						string[] fields = line.Split('|');

						if (fields.Length >= 4)
						{
							string id = fields[1].Trim();
							string name = fields[2].Trim();
							string email = fields[3].Trim();
							string password = fields[4].Trim();

							Customer customer = new Customer(id, name, email, password);
							customers.Add(customer);
						}
					}
				}
			}

			return customers;
		}








	}
}
