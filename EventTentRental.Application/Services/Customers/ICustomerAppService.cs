
using EventTentRental.Databases.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTentRental.Application.Services.Customers
{
	public interface ICustomerAppService
	{
		void Create(Customer model);	
		void Update(Customer model);	
		void Delete(string name);
		Customer GetByName(string name);
	}
}
