using DAL.Dtos.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Posts
{
	public interface IPostRepository
	{
		public Task<CreatePostDbResponse> CreateAsync(CreatePostDbRequest request);
	}
}
