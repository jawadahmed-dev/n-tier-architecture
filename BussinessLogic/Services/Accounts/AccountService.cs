using AutoMapper;
using BussinessLogic.Exceptions;
using BussinessLogic.Helper;
using BussinessLogic.Requests.Account;
using DataAccess.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Services.Accounts
{
	class AccountService : IAccountService
	{
		private readonly IMapper _mapper;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly IConfiguration _configuration;

		public AccountService
			(IMapper mapper, 
			UserManager<ApplicationUser> userManager, 
			SignInManager<ApplicationUser> signInManager,
			IConfiguration configuration)
		{
			_mapper = mapper;
			_userManager = userManager;
			_signInManager = signInManager;
			_configuration = configuration;
		}

		public async Task<LoginResponse> LoginAsync(LoginRequest request)
		{
			var user = await _userManager.FindByEmailAsync(request.Email);

			if (user == null) throw new BadRequestException("Email is incorrect");

			var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);

			if(!result.Succeeded) throw new BadRequestException("Password is incorrect");

			var response = new LoginResponse {
				UserName = user.UserName,
				Email = user.Email,
				Token = JwtHelper.GenerateToken(user, _configuration)
			};

			return response;
		}

		public async Task<RegisterResponse> RegisterAsync(RegisterRequest request)
		{
			var user = _mapper.Map<ApplicationUser>(request);

			var result = await _userManager.CreateAsync(user, request.Password);

			if (!result.Succeeded) throw new BadRequestException(result.Errors.FirstOrDefault()?.Description);

			return new RegisterResponse { Id = Guid.Parse((await _userManager.FindByEmailAsync(user.Email)).Id) };
		}
	}
}
