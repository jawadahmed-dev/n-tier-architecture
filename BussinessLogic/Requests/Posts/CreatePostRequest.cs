using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Requests.Posts
{
	public class CreatePostRequest
	{
		public string Name { get; set; }
	}

	public class CreatePostResponse
	{
		public bool isCreated { get; set; }
	}
}
