using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Dtos.Account
{
	public class LoginDbRequest
	{
		public string Email { get; set; }
		public string Password { get; set; }
	}
	public class LoginDbResponse
	{
		public bool IsSuccess { get; set; }
		public string Token { get; set; }
		public List<String> Errors { get; set; }
	}
}
