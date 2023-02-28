using AutoMapper;
using BussinessLogic.Exceptions;
using DataAccess;
using MediatR;
using Shared.Services.Impl;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BussinessLogic.RequestHandlers.Posts.Queries.GetAllPosts
{
	public class GetAllPostsQuery : IRequest<IEnumerable<GetAllPostsResponse>>
	{
	}

	public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, IEnumerable<GetAllPostsResponse>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IClaimService _claimService;

		public GetAllPostsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IClaimService claimService)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_claimService = claimService;
		}

		async Task<IEnumerable<GetAllPostsResponse>> IRequestHandler<GetAllPostsQuery, IEnumerable<GetAllPostsResponse>>.Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
		{
			var posts = await _unitOfWork.GetPosts().GetAllAsync(x => x.UserId == new Guid(_claimService.GetClaim("userId")));

			if (posts == null)
			{
				throw new BadRequestException("Something went wrong!");
			}

			var getAllPostsResponse = _mapper.Map<IEnumerable<GetAllPostsResponse>>(posts);
			return getAllPostsResponse;
		}
	}
}
