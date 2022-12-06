using EventTentRental.Application.Services.Authentications.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTentRental.Application.Services.Authentications
{
	public interface IAuthAppService
	{
		void Create(AuthDto model);
		AuthDto GetByEmail (string email);
		void Delete(AuthDto model);
	}
}
