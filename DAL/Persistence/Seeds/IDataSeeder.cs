using DemoApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistence.Seeds
{
	public interface IDataSeeder
	{
		Task SeedData(DataContext dataContext);
	}
}
