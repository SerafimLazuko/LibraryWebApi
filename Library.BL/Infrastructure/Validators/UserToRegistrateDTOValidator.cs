using FluentValidation;
using Library.BLL.DTO;

namespace Library.BLL.Infrastructure.Validators
{
    public class UserToRegisterDTOValidator : AbstractValidator<UserToRegisterDTO>
    {
        public UserToRegisterDTOValidator()
        {
            RuleFor(u => u.Name).NotEmpty().Length(3, 30);
            RuleFor(u => u.Login).NotEmpty().Length(6, 25);
            RuleFor(u => u.Password).NotEmpty().Length(6, 15);
        }
    }
}
