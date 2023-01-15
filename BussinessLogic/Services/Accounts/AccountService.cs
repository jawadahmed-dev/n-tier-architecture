using AutoMapper;
using BussinessLogic.Requests.Account;
using DAL.Dtos.Account;
using DAL.Repositories.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Services.Accounts
{
	class AccountService : IAccountService
	{
		private readonly IAccountRepository _accountRepository;
		private readonly IMapper _mapper;

		public AccountService(IAccountRepository accountRepository, IMapper mapper)
		{
			_accountRepository = accountRepository;
			_mapper = mapper;
		}

		public async Task<LoginResponse> LoginUserAsync(LoginRequest request)
		{
			var response = await _accountRepository.LoginUserAsync(_mapper.Map<LoginDbRequest>(request));
			return _mapper.Map<LoginResponse>(response);
		}

		public async Task<RegisterResponse> RegisterUserAsync(RegisterRequest request)
		{
			var response = await _accountRepository.RegisterUserAsync(_mapper.Map<RegisterDbRequest>(request));
			return _mapper.Map<RegisterResponse>(response);
		}
	}
}
