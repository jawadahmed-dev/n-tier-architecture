using AutoMapper;
using DAL.Dtos.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.MappingProfiles
{
	public class AccountProfile : Profile
	{
		public AccountProfile()
		{
			// Register Profile

			CreateMap<RegisterDbRequest, IdentityUser>();
		}
	}
}
