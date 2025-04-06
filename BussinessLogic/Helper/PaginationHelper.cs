using BussinessLogic.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Helper
{
	public class PaginationHelper
	{
		public static PagedResponse<T> PaginatedResponse<T>(T data, int currentPage, int pageSize, int totalCount) 
		{
			var totalPages = Decimal.ToInt32(Math.Ceiling(Decimal.Divide(totalCount, pageSize)));
			return new PagedResponse<T>(data, totalPages, currentPage, currentPage != 1, currentPage != totalPages);
		}
	}
}
