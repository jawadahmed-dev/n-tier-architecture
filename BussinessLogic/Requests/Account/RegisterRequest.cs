using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Requests.Account
{
	public class RegisterRequest
	{
		public string UserName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
	}

	public class RegisterResponse
	{
		public bool IsSuccess { get; set; }
		public List<String> Errors { get; set; }
	}
}
