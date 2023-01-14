using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Dtos.Posts
{
	public class CreatePostDbRequest
	{
		public string Name { get; set; }
	}
	public class CreatePostDbResponse
	{
		public bool isCreated { get; set; }
	}
}
