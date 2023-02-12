using DataAccess.Identity;
using DemoApi.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Extensions
{
	public static class IServicesCollectionExtenions
	{
		
		public static IServiceCollection InstallDataAccess(this IServiceCollection services, IConfiguration configuration)
		{
			InstallDatabase(services, configuration);
			InstallIdentity(services);

			return services;
		}

		public static void InstallIdentity(IServiceCollection services) {

			services
				.AddIdentity<ApplicationUser, IdentityRole>(options => {
					options.User.RequireUniqueEmail = true;
				})
				.AddEntityFrameworkStores<DataContext>();
		}

		public static void InstallDatabase(IServiceCollection services, IConfiguration configuration) {
			
			services.AddDbContext<DataContext>(options =>
				options.UseSqlServer(
					configuration.GetConnectionString("DefaultConnection"))
				);
		}

	}
}
