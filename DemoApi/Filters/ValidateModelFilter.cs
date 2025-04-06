using BussinessLogic.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApi.Filters
{
	public class ValidateModelFilter : IAsyncActionFilter
	{
		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			if (!context.ModelState.IsValid)
			{
				var errors = context.ModelState.Values
					.SelectMany(modelState => modelState.Errors)
					.Select(modelError => modelError.ErrorMessage);

				context.Result = new BadRequestObjectResult(ApiResult<string>.Failure(errors));
			}

		}

		public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
		{
			if (!context.ModelState.IsValid)
			{
				var errors = context.ModelState.Values
					.SelectMany(modelState => modelState.Errors)
					.Select(modelError => modelError.ErrorMessage);

				context.Result = new BadRequestObjectResult(ApiResult<string>.Failure(errors));
			}

			await next();
		}
	}
}
