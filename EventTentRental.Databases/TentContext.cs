using EventTentRental.Databases.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTentRental.Databases
{
	public class TentContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Mitra> Mitras { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Transaction> Transactions { get; set; }
		public TentContext(DbContextOptions<TentContext> options) : base(options) { }
	}
}
