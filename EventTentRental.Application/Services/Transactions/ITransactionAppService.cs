using EventTentRental.Application.Services.Transactions.Dto;
using EventTentRental.Databases.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTentRental.Application.Services.Transactions
{
	public interface ITransactionAppService
	{
		void Create(TransactionDto model);
		void Update(UpdateTransactionDto model);
		void Delete(int custId);
		Transaction GetByName(int custId);
		List<Transaction> GetAllTransaction();
	}
}
