using DAL.Dtos.Posts;
using DemoApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Posts
{
	public class PostRepository : IPostRepository
	{
		DataContext _dataContext;
		public async Task<CreatePostDbResponse> CreateAsync(CreatePostDbRequest request)
		{
			
		}
	}
}
