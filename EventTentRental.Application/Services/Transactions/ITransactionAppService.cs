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
		void Create(Transaction model);
		void Update(Transaction model);
		void Delete(int id);
	}
}
