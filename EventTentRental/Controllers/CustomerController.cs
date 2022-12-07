using EventTentRental.Application.Services.Customers;
using EventTentRental.Application.Services.Transactions;
using EventTentRental.Application.Services.Transactions.Dto;
using EventTentRental.Databases.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventTentRental.Controllers
{
	[Route("api/customer")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
		private readonly ICustomerAppService _customerAppService;
		private readonly ITransactionAppService _transactionAppService;
		public CustomerController(ICustomerAppService customerAppService, ITransactionAppService transactionAppService)
		{
			_customerAppService = customerAppService;
			_transactionAppService = transactionAppService;
		}

		[HttpPost("create")]
		public IActionResult Create([FromBody] Customer model)
		{
			try
			{
				if(model != null)
				{
					_customerAppService.Create(model);
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
		public IActionResult Update([FromBody] Customer model)
		{
			try
			{
				if (model != null)
				{
					_customerAppService.Update(model);
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
				_customerAppService.Delete(name);
				return Ok(new { Message = "Success" });
			}
			catch
			{
				return BadRequest();
			}
		}

		[HttpPost("create-transaction")]
		public IActionResult CreateTransaction([FromBody] TransactionDto model)
		{
			try
			{
				_transactionAppService.Create(model);
				return Ok(new { Message = "Success" });
			}
			catch
			{
				return BadRequest();
			}
		}

		[HttpPatch("update-payment")]
		public IActionResult UpdatePaymentTransaction([FromBody]UpdateTransactionDto model)
		{
			try
			{
				_transactionAppService.Update(model);
				return Ok(new { Message = "Success" });
			}
			catch
			{
				return BadRequest();
			}
		}

		[HttpGet("all-transaction")]
		public IActionResult GetAllTransaction()
		{
			try
			{
				var list = _transactionAppService.GetAllTransaction();
				return Ok(new { Data = list });
			}
			catch
			{
				return BadRequest();
			}
		}
	}
}
