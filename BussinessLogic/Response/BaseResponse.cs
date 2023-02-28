using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Requests.Common
{
	public class BaseResponse
	{
		public Guid Id { get; set; }
		public String CreatedOn { get; set; }
		public String? UpdatedOn { get; set; }
	}
}
