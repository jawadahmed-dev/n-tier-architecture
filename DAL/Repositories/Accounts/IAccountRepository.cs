using DAL.Dtos.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Accounts
{
	public interface IAccountRepository
	{
		public Task<RegisterDbResponse> RegisterUserAsync(RegisterDbRequest request);
		public Task<LoginDbResponse> LoginUserAsync(LoginDbRequest request);
	}
}
