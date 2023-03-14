using BussinessLogic.MappingProfiles;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Services.Impl;
using System;
using System.Reflection;

namespace BussinessLogic.Extensions
{
	public static class IServiceCollectionExtensions
	{
		public static IServiceCollection InstallBussinessLogic(this IServiceCollection services, IConfiguration configuration) {


			services.AddScoped<IClaimService, ClaimService>();
			InstallAutoMapper(services);
			InstallMediatR(services);
			InstallFluentValidation(services);
			return services;
		}

		private static void InstallFluentValidation(IServiceCollection services)
		{
			services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<IBussinessLogicLayerMarker>());
		}

		public static void InstallMediatR(IServiceCollection services)
		{
			services.AddMediatR(typeof(IBussinessLogicLayerMarker).Assembly);
		}

		public static void InstallAutoMapper(IServiceCollection services)
		{
			services.AddAutoMapper(typeof(IMappingProfilesMarker));
		}
	}
}
