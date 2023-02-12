using BussinessLogic.Requests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Requests.Posts
{
	public class PostRequest
	{
		public Guid Id { get; set; }
	}

	public class PostResponse : BaseResponse 
	{
		public string Name { get; set; }
	}
}
