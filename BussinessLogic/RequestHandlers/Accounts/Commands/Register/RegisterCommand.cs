using AutoMapper;
using BussinessLogic.Exceptions;
using DataAccess.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BussinessLogic.RequestHandlers.Accounts.Commands.Register
{
	public class RegisterCommand : IRequest<RegisterResponse>
	{
		public string UserName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
	}
	public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResponse>
	{
		private readonly IMapper _mapper;
		private readonly UserManager<ApplicationUser> _userManager;

		public RegisterCommandHandler(IMapper mapper, UserManager<ApplicationUser> userManager)
		{
			_mapper = mapper;
			_userManager = userManager;
		}

		public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
		{

			var user = _mapper.Map<ApplicationUser>(request);

			var result = await _userManager.CreateAsync(user, request.Password);

			if (!result.Succeeded) throw new BadRequestException(result.Errors.FirstOrDefault()?.Description);

			var registerResponse = new RegisterResponse { Id = Guid.Parse((await _userManager.FindByEmailAsync(user.Email)).Id) };

			return registerResponse;
		}
	}
}
