
using Dapper;
using EventTentRental.Databases;
using EventTentRental.Databases.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTentRental.Application.Services.Customers
{
	public class CustomerAppService : ICustomerAppService
	{
		private readonly string connStr = "Server=RHNRAFIF\\SQLEXPRESS;Database=TentRentDB;Trusted_Connection=True;TrustServerCertificate=True;";	

		public void Create(Customer model)
		{
			using (var connection = new SqlConnection(connStr))
			{
				connection.Open();
				var guid = Guid.NewGuid();
				var transaction = connection.BeginTransaction();
				try
				{
					connection.Execute("INSERT INTO Customer (Id, Name, Address) VALUES (@guid,@Name, @Address)", new
					{
						guid,
						model.Name,
						model.Address
					}, transaction);
					transaction.Commit();
				}
				catch
				{
					transaction.Rollback();
				}
				connection.Close();
			}			
		}

		public void Delete(string name)
		{
			using (var connection = new SqlConnection(connStr))
			{
				connection.Open();
				var transaction = connection.BeginTransaction();
				try
				{
					connection.Execute("DELETE FROM Customer WHERE Name = @Name", new
					{
						name,
					}, transaction);

					transaction.Commit();
				}
				catch
				{
					transaction.Rollback();
				}
				connection.Close();
			}
		}

		public Customer GetByName(string name)
		{
			var customer = new Customer();
			using (var connection = new SqlConnection(connStr))
			{
				connection.Open();
				try
				{
					var listCustomer = connection.Query<Customer>(@"SELECT * FROM Customer WHERE Name = @Name", new { name }).ToList();
					customer = listCustomer.FirstOrDefault();
					return customer;
				}
				catch
				{
					return customer;
				}
				connection.Close();
			}
		}

		public void Update(Customer model)
		{
			using (var connection = new SqlConnection(connStr))
			{
				connection.Open();
				var guid = Guid.NewGuid();
				var transaction = connection.BeginTransaction();
				try
				{
					var cust = GetByName(model.Name);
					if(cust == null)
					{
						return;
					}
					var Id = cust.Id;
					connection.Execute("UPDATE Customer SET Name = @Name, Address = @Address WHERE Id = @Id", new
					{
						Id,
						model.Name,
						model.Address,
					}, transaction);

					transaction.Commit();
				}
				catch
				{
					transaction.Rollback();
				}
				connection.Close();
			}				
		}
	}
}
