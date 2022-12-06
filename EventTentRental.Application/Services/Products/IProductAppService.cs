using EventTentRental.Databases.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTentRental.Application.Services.Products
{
	public interface IProductAppService
	{
		void Create(Product model);
		void Update(Product model);
		void Delete(int id);
	}
}
