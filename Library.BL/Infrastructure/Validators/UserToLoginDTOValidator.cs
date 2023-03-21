using FluentValidation;
using Library.BLL.DTO;

namespace Library.BLL.Infrastructure.Validators
{
    public class UserToLoginDTOValidator : AbstractValidator<UserToLoginDTO>
    {
        public UserToLoginDTOValidator()
        {
            RuleFor(u => u.Login).NotEmpty().Length(6, 25);
            RuleFor(u => u.Password).NotEmpty().Length(6, 15);
        }
    }
}
