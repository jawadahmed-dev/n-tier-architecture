using BussinessLogic.Requests.Posts;
using BussinessLogic.Services.Posts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PostController : ControllerBase
	{
		private IPostService _postService; 

		[HttpGet]
		public IActionResult Get() {
			return Ok(new { name = "john doe" });
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync([FromBody] CreatePostRequest request)
		{
			try {
				var response = await _postService.CreateAsync(request);

				return new OkObjectResult(new { isSuccess = true, data = response });

			}
			catch (Exception e) {

				return StatusCode(500, new { isSuccess = false, errorMessage = e.Message });
			}
		}
	}
}
