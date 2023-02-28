using BussinessLogic.RequestHandlers.Accounts.Commands.Register;
using BussinessLogic.RequestHandlers.Accounts.Queries.Login;
using BussinessLogic.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DemoApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly IMediator _mediatr;

		public AccountController(IMediator mediatr)
		{
			_mediatr = mediatr;
		}

		[HttpPost("register")]
		public async Task<IActionResult> RegisterUserAsyc([FromBody] RegisterCommand request)
		{
			return Ok(ApiResult<RegisterResponse>.Success(await _mediatr.Send(request)));
		}

		[HttpPost("login")]
		public async Task<IActionResult> LoginUserAsyc([FromQuery] LoginQuery request)
		{
			return Ok(ApiResult<LoginResponse>.Success(await _mediatr.Send(request)));
		}

	}
}
