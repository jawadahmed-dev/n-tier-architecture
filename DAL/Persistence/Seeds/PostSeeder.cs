using DAL.Entities;
using DemoApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistence.Seeds
{
	public class PostSeeder : IDataSeeder
	{
		public async Task SeedData(DataContext dataContext)
		{
			if (dataContext.Posts.Any()) return;

			var posts = new List<Post>
			{
				new Post {Id = Guid.NewGuid(), Name = "Turkey Disaster", UserId = Guid.NewGuid() },
				new Post {Id = Guid.NewGuid(), Name = "UFC New Heavy Weight Champion", UserId = Guid.NewGuid() },
				new Post {Id = Guid.NewGuid(), Name = "Chat GPT", UserId = Guid.NewGuid() },
			};

			dataContext.Posts.AddRange(posts);
			await dataContext.SaveChangesAsync();
		}
	}
}
