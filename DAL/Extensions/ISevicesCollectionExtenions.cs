using DataAccess;
using DataAccess.Identity;
using DataAccess.Persistence;
using DemoApi.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DAL.Extensions
{
	public static class IServicesCollectionExtenions
	{
		
		public static IServiceCollection InstallDataAccess(this IServiceCollection services, IConfiguration configuration)
		{
			InstallDatabase(services, configuration);
			InstallIdentity(services);
			InitializeDatabase(services);
			services.AddScoped<IUnitOfWork, UnitOfWork>();


			return services;
		}

		private static void InitializeDatabase(IServiceCollection services)
		{

			var serviceScope = services.BuildServiceProvider().CreateScope();
			var serviceProvider = serviceScope.ServiceProvider;
			var context = serviceProvider.GetRequiredService<DataContext>();

			// Call the Automated Migration method when the application starts
			AutomatedMigration.Migrate(context, serviceProvider);

		}

		public static void InstallIdentity(IServiceCollection services) {

			services
				.AddIdentity<ApplicationUser, IdentityRole>(options => {
					options.User.RequireUniqueEmail = true;
					options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+/ ";
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
