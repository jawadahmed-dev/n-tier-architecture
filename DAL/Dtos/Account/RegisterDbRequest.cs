using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Dtos.Account
{
	public class RegisterDbRequest
	{
		public string UserName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
	}

	public class RegisterDbResponse
	{
		public bool IsSuccess { get; set; }
		public List<String> Errors { get; set; }
	}
}
