using DataAccess.Persistence.Seeds;
using DemoApi.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistence
{
	public class AutomatedMigration
	{
		public static void Migrate(DataContext dbContext)
		{
			dbContext.Database.Migrate();
			var dataSeedersList = typeof(IDataAccessLayerMarker).Assembly.GetExportedTypes()
				.Where(x => x.IsAssignableTo(typeof(IDataSeeder)) && !x.IsAbstract)
				.Select(x => (IDataSeeder)Activator.CreateInstance(x)).ToList();

			foreach (var dataSeeder in dataSeedersList)
			{
				dataSeeder.SeedData(dbContext);
			}

		}
	}
}
