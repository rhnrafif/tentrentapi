using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTentRental.Databases.Models
{
	[Table("Product")]
	public class Product
	{
		[Key]
		public Guid Id { get; set; }
		public Guid MitraId { get; set; }
		public string Category { get; set; }
		public string Size { get;set; }
		public string Description { get; set; }
		public virtual Mitra Mitra { get; set;}
	}
}
