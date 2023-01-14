using BussinessLogic.Services.Posts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Installers
{
	public static class ServiceInstaller
	{
		public static IServiceCollection InstallServices(this IServiceCollection services) {

			// Post Service
			services.AddScoped<IPostService, PostService>();

			return services;
		}
	}
}
