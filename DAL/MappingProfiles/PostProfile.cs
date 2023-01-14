using AutoMapper;
using DAL.Dtos.Posts;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.MappingProfiles
{
	public class PostProfile : Profile
	{
		public PostProfile()
		{
			CreateMap<CreatePostDbRequest, Post>();
		}
	}
}
