using EventTentRental.Databases.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTentRental.Application.Services.Mitras
{
	public interface IMitraAppService
	{
		void Create(Mitra model);
		void Update(Mitra model);
		void Delete(string name);
		Mitra GetByName(string name);
	}
}
