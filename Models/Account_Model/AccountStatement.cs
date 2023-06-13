﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_UsingFileAsDatabase.Models.Account_Model
{
	internal class AccountStatement
	{
		public AccountStatement(string id, string name, string description, string amount, decimal balance, DateTime date)
		{
			Id = id;
			Name = name;
			Description = description;
			Amount = amount;
			Balance = balance;
			Date = date;
		}

		public string Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Amount  { get; set; }
		public decimal Balance { get; set; }
		public DateTime Date { get; set; }
	}
}
