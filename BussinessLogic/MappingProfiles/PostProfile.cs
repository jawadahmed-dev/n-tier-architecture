using AutoMapper;
using BussinessLogic.RequestHandlers.Posts.Commands;
using BussinessLogic.RequestHandlers.Posts.Queries.GetAllPosts;
using BussinessLogic.RequestHandlers.Posts.Queries.GetPagedPosts;
using DAL.Entities;

namespace BussinessLogic.MappingProfiles
{
	public class PostProfile : Profile
	{
		public PostProfile()
		{
			CreateMap<CreatePostCommand, Post>();
			CreateMap<Post, GetAllPostsResponse>();
			CreateMap<Post, GetPagedPostsResponse>();
		}
	}
}
