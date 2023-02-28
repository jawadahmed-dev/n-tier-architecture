using DataAccess.Repositories.Posts;
using DemoApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	public interface IUnitOfWork
	{
		IPostRepository GetPosts();
		Task<int> SaveChangesAsync();
	}

	public class UnitOfWork : IUnitOfWork
	{
		private readonly DataContext _dataContext;
		private IPostRepository _postRepository;
		public UnitOfWork(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public IPostRepository GetPosts()
		{
			if (_postRepository == null)
			{
				_postRepository = new PostRepository(_dataContext);
			}

			return _postRepository;
		}

		public async Task<int> SaveChangesAsync()
		{
			return await _dataContext.SaveChangesAsync();
		}
	}
}
