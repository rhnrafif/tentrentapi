using EventTentRental.Application.Services.Authentications.Dto;
using EventTentRental.Databases;
using EventTentRental.Databases.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTentRental.Application.Services.Authentications
{
	public class AuthAppService : IAuthAppService
	{
		private readonly TentContext _context;
		public AuthAppService(TentContext context)
		{
			_context = context;
		}
		public void Create(AuthDto model)
		{
			var user = new User()
			{
				Email= model.Email,
				Password = model.Password
			};
			 _context.Users.Add(user);
			_context.SaveChanges();
		}

		public void Delete(AuthDto model)
		{
			var userId = _context.Users.FirstOrDefault(w => w.Email == model.Email);
			if(userId != null)
			{
				var user = new User()
				{
					Email = model.Email,
					Password = model.Password
				};
				_context.Users.Remove(user);
				_context.SaveChanges();
			}
		}

		public AuthDto GetByEmail(string email)
		{
			try
			{
				var result = new AuthDto();
				var user = _context.Users.FirstOrDefault(w => w.Email == email);
				if(user != null)
				{
					return result;
				}

				return result;
			}
			catch
			{
				return new AuthDto();
			}
		}
	}
}
