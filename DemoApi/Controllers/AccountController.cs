using BussinessLogic.Requests;
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
		public async Task<IActionResult> RegisterUserAsyc([FromBody] RegisterRequest request)
		{
			return Ok(ApiResult<RegisterResponse>.Success(await _accountService.RegisterAsync(request)));
		}

		[HttpPost("login")]
		public async Task<IActionResult> LoginUserAsyc([FromQuery] LoginRequest request)
		{
			return Ok(ApiResult<LoginResponse>.Success(await _accountService.LoginAsync(request)));
		}

	}
}
