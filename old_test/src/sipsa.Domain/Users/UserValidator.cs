using FluentValidation;

namespace sipsa.Domain.Users
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Name).NotEmpty().Length(4, 60);
        }
    }
}