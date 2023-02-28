using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Response
{
	public class PagedResponse<T>
	{
		public PagedResponse(T data, int totalPages, int currentPage, bool previousPage, bool nextPage)
		{
			Data = data;
			TotalPages = totalPages;
			CurrentPage = currentPage;
			PreviousPage = previousPage;
			NextPage = nextPage;
		}

		public T Data { get; set; }
		public int TotalPages { get; set; }
		public int CurrentPage { get; set; }
		public bool PreviousPage { get; set; }
		public bool NextPage { get; set; }
	}
}
