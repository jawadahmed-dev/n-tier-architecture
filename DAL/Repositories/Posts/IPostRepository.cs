using DAL.Entities;
using DataAccess.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Posts
{
	public interface IPostRepository : IBaseRepository<Post>
	{
		public Task<IEnumerable<Post>> GetPagedPosts(int currentPage, int pageSize);
		public Task<int> GetAllPostsCount();
	}
}
