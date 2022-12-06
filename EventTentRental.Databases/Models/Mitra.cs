using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTentRental.Databases.Models
{
	[Table("Mitra")]
	public class Mitra
	{
		[Key]
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public int ProductId { get; set; }
	}
}
