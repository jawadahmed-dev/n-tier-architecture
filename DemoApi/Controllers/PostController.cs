using BussinessLogic.Requests;
using BussinessLogic.Requests.Posts;
using BussinessLogic.Services.Posts;
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

		public PostController(IPostService postService)
		{
			_postService = postService;
		}

		[HttpGet]
		public async Task<IActionResult> Get([FromQuery] PostRequest request)
		{
			return Ok(ApiResult<PostResponse>.Success(await _postService.GetAsync(request)));
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync([FromBody] CreatePostRequest request)
		{
			return Ok(ApiResult<CreatePostResponse>.Success(await _postService.CreateAsync(request)));
		}
	}
}
