using Dapper;
using EventTentRental.Databases;
using EventTentRental.Databases.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTentRental.Application.Services.Products
{
	public class ProductAppService : IProductAppService
	{
		private readonly string connStr = "Server=RHNRAFIF\\SQLEXPRESS;Database=TentRentDB;Trusted_Connection=True;TrustServerCertificate=True;";

		public void Create(Product model)
		{
			using (var connection = new SqlConnection(connStr))
			{
				connection.Open();
				var guid = Guid.NewGuid();
				var transaction = connection.BeginTransaction();
				try
				{
					connection.Execute("INSERT INTO Product (Id, MitraId, Name, Category, Size, Description) VALUES (@guid,@MitraId, @Name, @Category, @Size, @Description)", new
					{
						guid,
						model.MitraId,
						model.Name,
						model.Category,
						model.Size,
						model.Description
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
					var listProduct = GetByName(name);
					if(listProduct == null)
					{
						return;
					}

					connection.Execute("DELETE FROM Product WHERE Name = @Name", new
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

		public Product GetByName(string name)
		{
			var product = new Product();
			using (var connection = new SqlConnection(connStr))
			{
				connection.Open();
				try
				{
					var listProduct = connection.Query<Product>(@"SELECT * FROM Product WHERE Name = @Name", new { name }).ToList();
					product = listProduct.FirstOrDefault();
					return product;
				}
				catch
				{
					return product;
				}
				connection.Close();
			}
		}

		public List<Product> GetProducts()
		{
			List<Product> product = new List<Product>();
			using (var connection = new SqlConnection(connStr))
			{
				connection.Open();
				try
				{
					var listProduct = connection.Query<Product>(@"SELECT * FROM Product");
					product = listProduct.ToList();
					return product;
				}
				catch
				{
					return product;
				}
				connection.Close();
			}
		}

		public void Update(Product model)
		{
			using (var connection = new SqlConnection(connStr))
			{
				connection.Open();
				var guid = Guid.NewGuid();
				var transaction = connection.BeginTransaction();
				try
				{
					var prod = GetByName(model.Name);
					if (prod == null)
					{
						return;
					}
					var Id = prod.Id;
					connection.Execute("UPDATE Product SET MitraId = @MitraId, Name = @Name, Category = @Category, Size = @Size, Description = @Description WHERE Id = @Id", new
					{
						model.MitraId,
						model.Name,
						model.Category,
						model.Size,
						model.Description
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
