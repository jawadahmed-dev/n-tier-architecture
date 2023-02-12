using BussinessLogic.Requests.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Services.Posts
{
	public interface IPostService
	{
		public Task<CreatePostResponse> CreateAsync(CreatePostRequest request);
		public Task<PostResponse> GetAsync(PostRequest request);
	}
}
