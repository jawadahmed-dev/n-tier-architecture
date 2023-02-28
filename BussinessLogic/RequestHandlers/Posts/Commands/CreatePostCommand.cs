using AutoMapper;
using BussinessLogic.Exceptions;
using DAL.Entities;
using DataAccess;
using MediatR;
using Shared.Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BussinessLogic.RequestHandlers.Posts.Commands
{
	public class CreatePostCommand : IRequest<CreatePostResponse>
	{
		public String Name { get; set; }
	}

	public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, CreatePostResponse>
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IClaimService _claimService;

		public CreatePostCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IClaimService claimService)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;
			_claimService = claimService;
		}
		public async Task<CreatePostResponse> Handle(CreatePostCommand request, CancellationToken cancellationToken)
		{

			var post = _mapper.Map<Post>(request);

			post.UserId = new Guid(_claimService.GetUserId());

			post = await _unitOfWork.GetPosts().AddAsync(post);

			var isCreated = await _unitOfWork.SaveChangesAsync();

			if (isCreated < 1) throw new BadRequestException("Something went wrong!");

			return new CreatePostResponse { Id = post.Id };
		}
	}
}
