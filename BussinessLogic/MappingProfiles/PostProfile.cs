using AutoMapper;
using BussinessLogic.Requests.Posts;
using DAL.Dtos.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.MappingProfiles
{
	public class PostProfile : Profile
	{
		public PostProfile()
		{
			CreateMap<CreatePostRequest, CreatePostDbRequest>();
			CreateMap<CreatePostDbResponse, CreatePostResponse>();
		}
	}
}
