using AutoMapper;
using BussinessLogic.Requests.Account;
using DataAccess.Identity;

namespace BussinessLogic.MappingProfiles
{
	public class AccountProfile : Profile
	{
		public AccountProfile()
		{
			CreateMap<RegisterRequest, ApplicationUser>();
		}
	}
}
