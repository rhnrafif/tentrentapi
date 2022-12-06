using EventTentRental.Databases;
using EventTentRental.Databases.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTentRental.Application.Services.Products
{
	public class ProductAppService : IProductAppService
	{
		private readonly TentContext _context;
		public ProductAppService(TentContext context)
		{
			_context = context;
		}

		public void Create(Product model)
		{
			_context.Products.FromSql($"INSERT INTO Product (MitraId, Category, Size, Description) VALUES ({model.MitraId}, '{model.Category}', '{model.Size}' , '{model.Description}' )");
			_context.SaveChanges();
		}

		public void Delete(int id)
		{
			_context.Products.FromSql($"DELETE FROM Product WHERE Id={id}");
		}

		public void Update(Product model)
		{
			_context.Products.FromSql($"UPDATE Product SET MitraId = {model.MitraId}, Category = '{model.Category}', Size = '{model.Size}', Description = '{model.Description}' WHERE	Id = {model.Id}");
			_context.SaveChanges();
		}
	}
}
