using Dapper;
using EventTentRental.Databases;
using EventTentRental.Databases.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTentRental.Application.Services.Mitras
{
	public class MitraAppService : IMitraAppService
	{
		private readonly string connStr = "Server=RHNRAFIF\\SQLEXPRESS;Database=TentRentDB;Trusted_Connection=True;TrustServerCertificate=True;";
		
		public void Create(Mitra model)
		{
			using (var connection = new SqlConnection(connStr))
			{
				connection.Open();
				var guid = Guid.NewGuid();
				var transaction = connection.BeginTransaction();
				try
				{
					connection.Execute("INSERT INTO Mitra (Id, Name, Address) VALUES (@guid,@Name, @Address)", new
					{
						guid,
						model.Name,
						model.Address
					}, transaction);
					transaction.Commit();
				}
				catch
				{
					transaction.Rollback();
				}
				connection.Close();
			}
		}

		public void Delete(string name)
		{
			using (var connection = new SqlConnection(connStr))
			{
				connection.Open();
				var transaction = connection.BeginTransaction();
				try
				{
					connection.Execute("DELETE FROM Mitra WHERE Name = @Name", new
					{
						name,
					}, transaction);
					transaction.Commit();
				}
				catch
				{
					transaction.Rollback();
				}
				connection.Close();
			}
		}

		public Mitra GetByName(string name)
		{
			var mitra = new Mitra();
			using (var connection = new SqlConnection(connStr))
			{
				connection.Open();
				try
				{
					var listrMitra = connection.Query<Mitra>(@"SELECT * FROM Mitra WHERE Name = @Name", new { name }).ToList();
					mitra = listrMitra.FirstOrDefault();
					return mitra;
				}
				catch
				{
					return mitra;
				}
				connection.Close();
			}
		}

		public void Update(Mitra model)
		{
			using (var connection = new SqlConnection(connStr))
			{
				connection.Open();
				var guid = Guid.NewGuid();
				var transaction = connection.BeginTransaction();
				try
				{
					var cust = GetByName(model.Name);
					if (cust == null)
					{
						return;
					}
					var Id = cust.Id;
					connection.Execute("UPDATE Mitra SET Name = @Name, Address = @Address WHERE Id = @Id", new
					{
						Id,
						model.Name,
						model.Address,
					}, transaction);

					transaction.Commit();
				}
				catch
				{
					transaction.Rollback();
				}
				connection.Close();
			}
		}
	}
}
