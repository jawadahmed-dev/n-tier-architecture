using DAL.Entities;
using DemoApi.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistence
{
	public static class DbInitializer
	{
		public static void Initialize(DataContext dbContext) 
		{
			dbContext.Database.Migrate();

			InitializePosts(dbContext);
			
		}

		private async static void InitializePosts(DataContext dbContext)
		{
			if (dbContext.Posts.Any()) 
			{
				return;
			}

			var posts = new List<Post>
			{
				new Post {Id = Guid.NewGuid(), Name = "Turkey Disaster", UserId = Guid.NewGuid() },
				new Post {Id = Guid.NewGuid(), Name = "UFC New Heavy Weight Champion", UserId = Guid.NewGuid() },
				new Post {Id = Guid.NewGuid(), Name = "Chat GPT", UserId = Guid.NewGuid() },
			};

			dbContext.Posts.AddRange(posts);
			await dbContext.SaveChangesAsync();

		}
	}
}
