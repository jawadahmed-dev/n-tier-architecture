using DAL.Repositories.Accounts;
using DAL.Repositories.Posts;
using DemoApi.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Extensions
{
	public static class IServicesCollectionExtenions
	{
		
		public static IServiceCollection InstallDb(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<DataContext>(options =>
				options.UseSqlServer(
					configuration.GetConnectionString("DefaultConnection")));

			services.AddIdentity<IdentityUser, IdentityRole>(options => {
				options.User.RequireUniqueEmail = true;
			})
				.AddEntityFrameworkStores<DataContext>();

			return services;
		}

		public static IServiceCollection InstallRepositories(this IServiceCollection services)
		{

			// Post Repository
			services.AddScoped<IPostRepository, PostRepository>();

			// Account Repository
			services.AddScoped<IAccountRepository, AccountRepository>();

			return services;
		}
	}
}
