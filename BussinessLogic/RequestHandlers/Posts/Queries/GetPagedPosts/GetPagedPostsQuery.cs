using AutoMapper;
using BussinessLogic.Helper;
using BussinessLogic.Response;
using DataAccess;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BussinessLogic.RequestHandlers.Posts.Queries.GetPagedPosts
{
	public class GetPagedPostsQuery : IRequest<PagedResponse<IEnumerable<GetPagedPostsResponse>>>
	{
		public int CurrentPage { get; set; }
		public int PageSize { get; set; }
	}

	public class GetPagedPostsQueryHandler : IRequestHandler<GetPagedPostsQuery, PagedResponse<IEnumerable<GetPagedPostsResponse>>>
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;

		public GetPagedPostsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<PagedResponse<IEnumerable<GetPagedPostsResponse>>> Handle(GetPagedPostsQuery request, CancellationToken cancellationToken)
		{
			var totalPostsCount = await _unitOfWork.GetPosts().GetAllPostsCount();

			var pagedPosts = await _unitOfWork.GetPosts().GetPagedPosts(request.CurrentPage, request.PageSize);
			var pagedPostsResponse = _mapper.Map<IEnumerable<GetPagedPostsResponse>>(pagedPosts);

			var response = PaginationHelper
				.PaginatedResponse<IEnumerable<GetPagedPostsResponse>>(pagedPostsResponse, request.CurrentPage, request.PageSize, totalPostsCount);

			return response;
		}
	}
}
