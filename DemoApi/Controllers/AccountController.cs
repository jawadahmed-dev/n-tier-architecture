using BussinessLogic.Requests.Account;
using BussinessLogic.Services.Accounts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DemoApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private IAccountService _accountService;

		public AccountController(IAccountService accountService)
		{
			_accountService = accountService;
		}

		[HttpPost("register")]
		public async Task<IActionResult> RegisterUserAsyc([FromBody] RegisterRequest request) {

			try
			{
				var response = await _accountService.RegisterUserAsync(request);

				if (!response.IsSuccess) return new BadRequestObjectResult(new { isSuccess = false, errors = response.Errors });

				return new OkObjectResult(new {isSucess = true, message = "user has been successfully registered!"});
			}
			catch (Exception e)
			{

				return StatusCode(500, new { isSuccess = false, errorMessage = e.Message });
			}
		}

		[HttpPost("login")]
		public async Task<IActionResult> LoginUserAsyc([FromQuery] LoginRequest request)
		{

			try
			{
				var response = await _accountService.LoginUserAsync(request);

				if (!response.IsSuccess) return new BadRequestObjectResult(new { isSuccess = response.IsSuccess, errors = response.Errors });

				return new OkObjectResult(new { isSucess = true, token = response.Token});
			}
			catch (Exception e)
			{

				return StatusCode(500, new { isSuccess = false, errorMessage = e.Message });
			}
		}

	}
}
