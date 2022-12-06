using EventTentRental.Databases;
using EventTentRental.Databases.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTentRental.Application.Services.Transactions
{
	public class TransactionAppService : ITransactionAppService
	{
		private readonly TentContext _context;
		public TransactionAppService(TentContext context)
		{
			_context = context;
		}
		public void Create(Transaction model)
		{
			_context.Transactions
				.FromSql($"INSERT INTO Transaction (CustomerId, ProductId, Quantity, StartDate, EndDate) VALUES ({model.CustomerId}, {model.ProductId}, {model.Quantity}, {DateTime.Now}, {DateTime.Now.AddHours(24)})");
			_context.SaveChanges();
		}

		public void Delete(int id)
		{
			_context.Transactions.FromSql($"DELETE FROM Transaction WHERE Id = {id}");
		}

		public void Update(Transaction model)
		{
			_context.Transactions.FromSql($"UPDATE Transaction SET CustomerId = {model.CustomerId}, ProductId = {model.ProductId}, Quantity = {model.Quantity}, StartDate = {DateTime.Now}, EndDate = {DateTime.Now.AddHours(24)} WHERE Id = {model.Id}");
			_context.SaveChanges();
		}
	}
}
