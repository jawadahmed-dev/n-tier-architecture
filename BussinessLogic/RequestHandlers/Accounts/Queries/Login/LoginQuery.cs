using BussinessLogic.Exceptions;
using BussinessLogic.Helper;
using DataAccess;
using DataAccess.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BussinessLogic.RequestHandlers.Accounts.Queries.Login
{
	public class LoginQuery : IRequest<LoginResponse>
	{
		public string Email { get; set; }
		public string Password { get; set; }
	}

	public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginResponse>
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IConfiguration _configuration;
		private readonly SignInManager<ApplicationUser> _signInManager;

		public LoginQueryHandler(
			SignInManager<ApplicationUser> signInManager,
			UserManager<ApplicationUser> userManager,
			IConfiguration configuration
			)
		{
			_userManager = userManager;
			_configuration = configuration;
			_signInManager = signInManager;
		}

		public async Task<LoginResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
		{
			var user = await _userManager.FindByEmailAsync(request.Email);

			if (user == null) throw new BadRequestException("Email is incorrect");

			var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);

			if (!result.Succeeded) throw new BadRequestException("Password is incorrect");

			var response = new LoginResponse
			{
				UserName = user.UserName,
				Email = user.Email,
				Token = JwtHelper.GenerateToken(user, _configuration)
			};

			return response;
		}
	}
}
