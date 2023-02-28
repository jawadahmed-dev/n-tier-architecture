using AutoMapper;
using BussinessLogic.RequestHandlers.Accounts.Commands.Register;
using DataAccess.Identity;

namespace BussinessLogic.MappingProfiles
{
	public class AccountProfile : Profile
	{
		public AccountProfile()
		{
			CreateMap<RegisterCommand, ApplicationUser>();
		}
	}
}
