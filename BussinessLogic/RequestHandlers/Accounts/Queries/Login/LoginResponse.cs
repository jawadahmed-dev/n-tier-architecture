using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.RequestHandlers.Accounts.Queries.Login
{
	public class LoginResponse
	{
		public string UserName { get; set; }
		public string Email { get; set; }
		public string Token { get; set; }
	}
}
