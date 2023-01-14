using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApi.Installers
{
	public static class MvcInstaller
	{
		public static IServiceCollection InstallMvc(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddControllersWithViews();

			services.AddSwaggerGen(options => {
				options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "TweetBook Api", Version = "v1" });
			});

			return services;
		}
	}
}
