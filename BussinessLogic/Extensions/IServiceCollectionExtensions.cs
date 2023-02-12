using BussinessLogic.MappingProfiles;
using BussinessLogic.Services.Accounts;
using BussinessLogic.Services.Posts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Extensions
{
	public static class IServiceCollectionExtensions
	{
		public static IServiceCollection InstallBussinessLogic(this IServiceCollection services, IConfiguration configuration) {

			InstallServices(services);
			InstallAutoMapper(services);

			return services;
		}

		public static void InstallServices(IServiceCollection services)
		{

			// Posts Service
			services.AddScoped<IPostService, PostService>();

			// Account Service
			services.AddScoped<IAccountService, AccountService>();
		}

		public static void InstallAutoMapper(IServiceCollection services)
		{
			services.AddAutoMapper(typeof(IMappingProfilesMarker));
		}
	}
}
