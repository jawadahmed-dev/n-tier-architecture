using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.RequestHandlers.Posts.Commands
{
	public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
	{
		public CreatePostCommandValidator()
		{
			RuleFor(x => x.Name)
				.NotEmpty();

			RuleFor(x => x.Name)
				.MinimumLength(3);
		}
	}
}
