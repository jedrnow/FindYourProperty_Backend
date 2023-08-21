using FluentValidation;
using MediatR;
using PropertyScraper.Data;

namespace PropertyScraper.Commands
{
    public record LoginUserCommand:IRequest<string>
    {
        public string Email { get; init; }
        public string Password { get; init; }
    }

    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        LoginUserCommandValidator()
        {
            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Length(DefaultSettings.MinEmailLength, DefaultSettings.MaxEmailLength)
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.Net4xRegex);


            RuleFor(x => x.Password)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Length(DefaultSettings.MinPasswordLength, DefaultSettings.MaxPasswordLength);
        }
    }
}
