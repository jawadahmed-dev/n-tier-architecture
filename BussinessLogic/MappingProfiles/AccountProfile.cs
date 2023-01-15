using AutoMapper;
using BussinessLogic.Requests.Account;
using DAL.Dtos.Account;

namespace BussinessLogic.MappingProfiles
{
	public class AccountProfile : Profile
	{
		public AccountProfile()
		{
			CreateMap<RegisterRequest, RegisterDbRequest>();
			CreateMap<RegisterDbResponse, RegisterResponse>();

			// Login Profile
			CreateMap<LoginRequest, LoginDbRequest>();
			CreateMap<LoginDbResponse, LoginResponse>();
		}
	}
}
