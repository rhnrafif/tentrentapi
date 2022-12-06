
using EventTentRental.Databases;
using EventTentRental.Databases.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTentRental.Application.Services.Customers
{
	public class CustomerAppService : ICustomerAppService
	{
		private readonly TentContext _context;
		public CustomerAppService(TentContext context)
		{
			_context = context;
		}

		public void Create(Customer model)
		{
			var guid = Guid.NewGuid();
			_context.Database.ExecuteSqlRaw($"INSERT INTO Customer (Id, Name, Address) VALUES ({guid},'{model.Name}', '{model.Address}') ");
			_context.SaveChanges();
		}

		public void Delete(string name)
		{
			_context.Database.ExecuteSqlRaw(@"DELETE FROM Customer WHERE Name = '{name}'");
			_context.SaveChanges();
		}

		public void Update(Customer model)
		{
			var customer = _context.Customers.FromSql($"SELECT * FROM Customer WHERE Name = {model.Name}");
			_context.Customers.FromSql($"UPDATE Customer SET Name = '{model.Name}', Address = '{model.Address}' WHERE Id = {model.Id} ");
			_context.SaveChanges();
		}
	}
}
