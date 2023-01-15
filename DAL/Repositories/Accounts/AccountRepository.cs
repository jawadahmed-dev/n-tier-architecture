using AutoMapper;
using DAL.Dtos.Account;
using Domain.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Accounts
{
	public class AccountRepository : IAccountRepository
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly IMapper _mapper;
		private readonly IConfiguration _configuration;

		public AccountRepository(UserManager<IdentityUser> userManager, IMapper mapper, IConfiguration configuration)
		{
			_userManager = userManager;
			_mapper = mapper;
			_configuration = configuration;
		}

		public async Task<LoginDbResponse> LoginUserAsync(LoginDbRequest request)
		{
			var user = await _userManager.FindByEmailAsync(request.Email);

			if (user == null) return new LoginDbResponse { IsSuccess = false, Errors = new List<String> {"user doesn't exist!"} };

			var isVerified = await _userManager.CheckPasswordAsync(user, request.Password);

			if(!isVerified) return new LoginDbResponse { IsSuccess = false, Errors = new List<String> { "email or password isn't correct!" } };

				var tokenDescriptor = new SecurityTokenDescriptor
				{
					Subject = new ClaimsIdentity(new Claim[]
					{
						new Claim("UserID", user.Id.ToString()),
						new Claim("UserName", user.UserName),
					}),
					Expires = DateTime.UtcNow.AddMinutes(60),
					SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection(nameof(JwtOptions)).ToString())), SecurityAlgorithms.HmacSha384Signature)
				};
				var tokenhandler = new JwtSecurityTokenHandler();
				var securityHandler = tokenhandler.CreateToken(tokenDescriptor);
				var token = tokenhandler.WriteToken(securityHandler);
				
			return new LoginDbResponse { IsSuccess = true, Token = token};
		}

		public async Task<RegisterDbResponse> RegisterUserAsync(RegisterDbRequest request)
		{
			var user = _mapper.Map<IdentityUser>(request);
			var result = await _userManager.CreateAsync(user, request.Password);
			
			if (!result.Succeeded) {

				var response = new RegisterDbResponse { IsSuccess = false, Errors = new List<String>()};
				
				foreach (var error in result.Errors) {
					response.Errors.Add(error.Description);
				}
				return response;
			}

			return new RegisterDbResponse { IsSuccess = true };
		}
	}
}
