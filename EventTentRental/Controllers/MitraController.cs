using EventTentRental.Application.Services.Mitras;
using EventTentRental.Application.Services.Products;
using EventTentRental.Databases.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventTentRental.Controllers
{
	[Route("api/mitra")]
	[ApiController]
	public class MitraController : ControllerBase
	{
		private readonly IMitraAppService _mitraAppService;
		private readonly IProductAppService _productAppService;
		public MitraController(IMitraAppService mitraAppService, IProductAppService productAppService)
		{
			_mitraAppService = mitraAppService;
			_productAppService = productAppService;
		}

		[HttpPost("create")]
		public IActionResult Create([FromBody] Mitra model)
		{
			try
			{
				if (model != null)
				{
					_mitraAppService.Create(model);
					return Ok(new { Message = "Succes" });
				}
				return BadRequest();
			}
			catch
			{
				return BadRequest(ModelState);
			}
		}

		[HttpPatch("update")]
		public IActionResult Update([FromBody] Mitra model)
		{
			try
			{
				if (model != null)
				{
					_mitraAppService.Update(model);
					return Ok(new { Message = "Succes" });
				}
				return BadRequest();
			}
			catch
			{
				return BadRequest(ModelState);
			}
		}

		[HttpDelete("delete")]
		public IActionResult Delete(string name)
		{
			try
			{
				_mitraAppService.Delete(name);
				return Ok(new { Message = "Success" });
			}
			catch
			{
				return BadRequest();
			}
		}

		//product
		[HttpPost("create-product")]
		public IActionResult CreateProduct([FromBody] Product model)
		{
			try
			{
				_productAppService.Create(model);
				return Ok(new { Message = "Success" });
			}
			catch
			{
				return BadRequest();
			}
		}

		[HttpPatch("update-product")]
		public IActionResult UpdateProduct([FromBody] Product model)
		{
			try
			{
				_productAppService.Update(model);
				return Ok(new { Message = "Success" });
			}
			catch
			{
				return BadRequest();
			}
		}

		[HttpDelete("delete-product")]
		public IActionResult DeleteProduct(string name)
		{
			try
			{
				_productAppService.Delete(name);
				return Ok(new { Message = "Success" });
			}
			catch
			{
				return BadRequest();
			}
		}
	}
}
