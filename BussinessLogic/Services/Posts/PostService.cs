using AutoMapper;
using BussinessLogic.Exceptions;
using BussinessLogic.Requests.Posts;
using DAL.Entities;
using DemoApi.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Services.Posts
{
	public class PostService : IPostService
	{
		private readonly IMapper _mapper;
		private readonly DataContext _context;

		public PostService( IMapper mapper, DataContext context)
		{
			_mapper = mapper;
			_context = context;
		}

		public async Task<CreatePostResponse> CreateAsync(CreatePostRequest request)
		{
			var post = (await _context.Posts.AddAsync(_mapper.Map<Post>(request))).Entity;

			var result = await _context.SaveChangesAsync();

			if (result < 1) throw new UnprocessableRequestException("Post couldn't be created");  

			var response = new CreatePostResponse { 
				Id = post.Id,
				CreatedOn = post.CreatedOn.ToString("MM/dd/yyyy HH:mm")
			};

			return response;
		}

		public async Task<PostResponse> GetAsync(PostRequest request)
		{

			var post = await _context
				.Posts
				.Where(post => post.Id == request.Id)
				.Select( post => new PostResponse { 
					Id = post.Id,
					Name = post.Name,
					UpdatedOn = post.UpdatedOn.Value.ToString("MM/dd/yyyy HH:mm"),
					CreatedOn = post.CreatedOn.ToString("MM/dd/yyyy HH:mm")
				})
				.FirstOrDefaultAsync();

			if (post == null) throw new ResourceNotFoundException(typeof(Post));

			var response = post;

			return response;
		}
	}
}
