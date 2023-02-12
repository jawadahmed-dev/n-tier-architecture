using BussinessLogic.Requests.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Services.Accounts
{
	public interface IAccountService
	{
		public Task<RegisterResponse> RegisterAsync(RegisterRequest request);
		public Task<LoginResponse> LoginAsync(LoginRequest request);
	}
}
