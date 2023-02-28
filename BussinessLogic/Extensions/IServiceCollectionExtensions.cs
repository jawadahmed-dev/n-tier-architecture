using BussinessLogic.MappingProfiles;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Services.Impl;

namespace BussinessLogic.Extensions
{
	public static class IServiceCollectionExtensions
	{
		public static IServiceCollection InstallBussinessLogic(this IServiceCollection services, IConfiguration configuration) {


			services.AddScoped<IClaimService, ClaimService>();
			InstallAutoMapper(services);
			InstallMediatR(services);
			return services;
		}

		public static void InstallMediatR(IServiceCollection services)
		{
			services.AddMediatR(typeof(IMappingProfilesMarker).Assembly);
		}

		public static void InstallAutoMapper(IServiceCollection services)
		{
			services.AddAutoMapper(typeof(IMappingProfilesMarker));
		}
	}
}
