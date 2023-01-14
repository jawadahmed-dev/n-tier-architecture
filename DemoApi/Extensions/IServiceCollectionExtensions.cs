using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApi.Extensions
{
	public static class IServiceCollectionExtensions
	{
		public static IServiceCollection InstallMvc(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddControllersWithViews();

			services.AddSwaggerGen(options => {
				options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "TweetBook Api", Version = "v1" });
			});

			return services;
		}

		public static IServiceCollection InstallAutoMapper(this IServiceCollection services)
		{
			var mapperConfig = new MapperConfiguration(mc =>
			{
				// Post Profiles
				mc.AddProfile<DAL.MappingProfiles.PostProfile>();
				mc.AddProfile<BussinessLogic.MappingProfiles.PostProfile>();

			});

			IMapper mapper = mapperConfig.CreateMapper();
			services.AddSingleton(mapper);
			return services;
		}


	}
}
