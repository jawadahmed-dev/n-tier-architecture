using AutoMapper;
using BussinessLogic.Requests.Posts;
using DAL.Entities;

namespace BussinessLogic.MappingProfiles
{
	public class PostProfile : Profile
	{
		public PostProfile()
		{
			CreateMap<CreatePostRequest, Post>();
		}
	}
}
