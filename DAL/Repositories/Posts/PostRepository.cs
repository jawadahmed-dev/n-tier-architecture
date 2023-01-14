using AutoMapper;
using DAL.Dtos.Posts;
using DAL.Entities;
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
		private readonly DataContext _dataContext;
		private readonly IMapper _mapper;

		public PostRepository(DataContext dataContext, IMapper mapper)
		{
			_dataContext = dataContext;
			_mapper = mapper;
		}

		public async Task<CreatePostDbResponse> CreateAsync(CreatePostDbRequest request)
		{
			await _dataContext.Posts.AddAsync(_mapper.Map<Post>(request));

			var created = await _dataContext.SaveChangesAsync();

			return new CreatePostDbResponse { isCreated = created > 0 };
		}
	}
}
