using EventTentRental.Databases;
using EventTentRental.Databases.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTentRental.Application.Services.Mitras
{
	public class MitraAppService : IMitraAppService
	{
		private readonly TentContext _context;
		public MitraAppService(TentContext context)
		{
			_context = context;
		}

		public void Create(Mitra model)
		{
			_context.Mitras.FromSql($"INSERT INTO Mitra (Name, Address, ProductId) VALUES ('{model.Name}', '{model.Address}', {model.ProductId} )" );
			_context.SaveChanges();
		}

		public void Delete(string name)
		{
			_context.Mitras.FromSql($"DELETE FROM Customer WHERE Name = '{name}'");
			_context.SaveChanges();
		}

		public void Update(Mitra model)
		{
			_context.Mitras.FromSql($"UPDATE Mitra SET Name = '{model.Name}', Address = '{model.Address}, ProductId = {model.ProductId}' WHERE Id = {model.Id} ");
			_context.SaveChanges();
		}
	}
}
