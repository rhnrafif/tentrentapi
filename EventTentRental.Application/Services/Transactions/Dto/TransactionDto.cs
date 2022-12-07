using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTentRental.Application.Services.Transactions.Dto
{
	public class TransactionDto
	{
		public int CustomerId { get; set; }
		public int ProductId { get; set; }
		public int Quantity { get; set; }
	}
}
