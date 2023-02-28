using DAL.Entities;
using DataAccess.Repositories.Common;
using DemoApi.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Posts
{
	public class PostRepository : BaseRepository<Post>, IPostRepository
	{
		public PostRepository(DataContext dataContext) : base(dataContext)
		{

		}

		public async Task<int> GetAllPostsCount()
		{
			return await _dataContext.Posts.AsNoTracking().CountAsync();
		}

		public async Task<IEnumerable<Post>> GetPagedPosts(int currentPage, int pageSize)
		{
			return await _dataContext
				.Posts
				.AsNoTracking()
				.Skip((currentPage - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync();
				
		}
	}
}
