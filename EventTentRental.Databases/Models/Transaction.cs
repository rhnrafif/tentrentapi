using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTentRental.Databases.Models
{
	[Table("Transaction")]
	public class Transaction
	{
		public Guid Id { get; set; }
		public int CustomerId { get; set; }
		public int ProductId { get; set; }
		public int Quantity { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
	}
}
