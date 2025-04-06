using DataAccess.Identity;
using DemoApi.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistence.Seeds
{
	public class UserSeeder : IDataSeeder
	{
		public async Task SeedData(DataContext dataContext, IServiceProvider serviceProvider)
		{
			
			var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
			var	userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

			if (userManager.Users.Any()) return;

			// Creating Roles

			var rolesList = new List<IdentityRole>
			{
				new IdentityRole { Id = "e29bd4a9-cb95-496f-83aa-8eaf17a1107a", Name = "Admin"},
				new IdentityRole { Id = "3ba64227-7dc9-40c7-ae63-c53f6e8cbc97", Name = "User"}
			};

			foreach (var role in rolesList)
			{
				await roleManager.CreateAsync(role);
			}

			// Creating Users And Assigning Roles

			var admin = new ApplicationUser { Id = "c4e0b883-88fe-4663-8e4f-06af90ca6a5e", UserName = "Rick Marshall", Email = "rick@gmail.com" };
			var user = new ApplicationUser { Id = "77929f01-60cd-4c6c-84c6-6af571391f62", UserName = "Vega Punk", Email = "vega@gmail.com" };

			var resultuser = await userManager.CreateAsync(admin);
			var roleResult = await userManager.AddToRoleAsync(admin, "Admin");

			await userManager.CreateAsync(user);
			await userManager.AddToRoleAsync(user, "User");

		}
	}
}
