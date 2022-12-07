using Dapper;
using EventTentRental.Application.Services.Transactions.Dto;
using EventTentRental.Databases;
using EventTentRental.Databases.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTentRental.Application.Services.Transactions
{
	public class TransactionAppService : ITransactionAppService
	{
		private readonly string connStr = "Server=RHNRAFIF\\SQLEXPRESS;Database=TentRentDB;Trusted_Connection=True;TrustServerCertificate=True;";

		public void Create(TransactionDto model)
		{
			using (var connection = new SqlConnection(connStr))
			{
				connection.Open();
				var guid = Guid.NewGuid();
				var startdate = DateTime.Now;
				var endDate = DateTime.Now.AddDays(1);
				bool isDone = false;
				var transaction = connection.BeginTransaction();
				try
				{
					connection.Execute("INSERT INTO Transactions (Id, CustomerId, ProductId, Quantity, StartDate, EndDate, IsDone) VALUES (@guid,@CustomerId, @ProductId, @Quantity, @StartDate, @EndDate, @IsDone)", new
					{
						guid,
						model.CustomerId,
						model.ProductId,
						model.Quantity,
						startdate,
						endDate,
						isDone
					}, transaction) ;
					transaction.Commit();
				}
				catch
				{
					transaction.Rollback();
				}
				connection.Close();
			}
		}

		public void Delete(int custId)
		{
			using (var connection = new SqlConnection(connStr))
			{
				connection.Open();
				var transaction = connection.BeginTransaction();
				try
				{
					var trans = GetByName(custId);
					if (trans == null)
					{
						return;
					}

					connection.Execute("DELETE FROM Transactions WHERE Id = @Id", new
					{
						trans.Id,
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

		public List<Transaction> GetAllTransaction()
		{
			List<Transaction> trans = new List<Transaction>();
			using (var connection = new SqlConnection(connStr))
			{
				connection.Open();
				try
				{
					var listTrans = connection.Query<Transaction>(@"SELECT * FROM Transactions");
					trans = listTrans.ToList();
					return trans;
				}
				catch
				{
					return trans;
				}
				connection.Close();
			}
		}

		public Transaction GetByName(int custId)
		{
			var trans = new Transaction();
			using (var connection = new SqlConnection(connStr))
			{
				connection.Open();
				try
				{
					var listTrans = connection.Query<Transaction>(@"SELECT * FROM Transactions WHERE CustomerId = @CustomerId", new { custId }).ToList();
					trans = listTrans.FirstOrDefault( w => w.IsDone == true);
					return trans;
				}
				catch
				{
					return trans;
				}
				connection.Close();
			}
		}

		public void Update(UpdateTransactionDto model)
		{
			using (var connection = new SqlConnection(connStr))
			{
				connection.Open();				
				bool isDone = true;
				var transaction = connection.BeginTransaction();
				try
				{
					var trans = GetByName(model.CustomerId);
					if (trans == null)
					{
						return;
					}
					var Id = trans.Id;

					connection.Execute("UPDATE Transactions SET IsDone = @IsDone)", new { isDone }, transaction);
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
