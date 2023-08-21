using FluentValidation;
using MediatR;
using PropertyScraper.Data;

namespace PropertyScraper.Commands
{
    public record RegisterUserCommand:IRequest<bool>
    {
        public string Username { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
    }

    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.Username)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Length(DefaultSettings.MinUsernameLength, DefaultSettings.MaxUserNameLength);

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
