using EventTentRental.Application.Services.Authentications;
using EventTentRental.Application.Services.Authentications.Dto;
using EventTentRental.Databases.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventTentRental.Controllers
{
	[Route("api/auth")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IAuthAppService _authAppService;
		public AuthController(IAuthAppService authAppService)
		{
			_authAppService = authAppService;
		}

		[HttpPost]
		public IActionResult Register([FromBody] AuthDto model)
		{
			try
			{				
				if(model != null)
				{
					_authAppService.Create(model);
					
					return Ok(new {Message = "Succes"});
				}

				return BadRequest();				
			}
			catch
			{
				return BadRequest();
			}
			
		}

	}
}
