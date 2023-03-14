using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.RequestHandlers.Accounts.Commands.Register
{
	public class RegisterCommandValidator: AbstractValidator<RegisterCommand>
	{
		public RegisterCommandValidator()
		{
			RuleFor(x => x.UserName)
			.Length(5, 20);
		}
	}
}
