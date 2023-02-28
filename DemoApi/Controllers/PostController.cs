using BussinessLogic.RequestHandlers.Posts.Commands;
using BussinessLogic.RequestHandlers.Posts.Queries.GetAllPosts;
using BussinessLogic.RequestHandlers.Posts.Queries.GetPagedPosts;
using BussinessLogic.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class PostController : ControllerBase
	{
		private IMediator _mediator;

		public PostController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("GetPagedPosts")]
		public async Task<IActionResult> Get([FromQuery] GetPagedPostsQuery request)
		{
			return Ok(ApiResult<PagedResponse<IEnumerable<GetPagedPostsResponse>>>.Success(await _mediator.Send(request)));
		}

		[HttpGet("Get")]
		public async Task<IActionResult> Get([FromQuery] GetAllPostsQuery request)
		{
			return Ok(ApiResult<IEnumerable<GetAllPostsResponse>>.Success(await _mediator.Send(request)));
		}

		
		[HttpPost("Create")]
		public async Task<IActionResult> CreateAsync([FromBody] CreatePostCommand request)
		{
			return Ok(ApiResult<CreatePostResponse>.Success(await _mediator.Send(request)));
		}
	}
}
