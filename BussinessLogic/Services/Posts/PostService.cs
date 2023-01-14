using AutoMapper;
using BussinessLogic.Requests.Posts;
using DAL.Dtos.Posts;
using DAL.Repositories.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Services.Posts
{
	public class PostService : IPostService
	{
		IPostRepository _postRepository;
		private readonly IMapper _mapper;

		public PostService(IPostRepository postRepository, IMapper mapper)
		{
			_postRepository = postRepository;
			_mapper = mapper;
		}

		public  async Task<CreatePostResponse> CreateAsync(CreatePostRequest request)
		{
			var response = await _postRepository.CreateAsync(_mapper.Map<CreatePostDbRequest>(request));

			return _mapper.Map<CreatePostResponse>(response);
		}
	}
}
