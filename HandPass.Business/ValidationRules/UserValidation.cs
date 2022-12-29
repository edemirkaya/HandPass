using FluentValidation;
using HandPass.Entities.Entitiy;

namespace HandPass.Business.ValidationRules
{
    public class UserValidation:AbstractValidator<UserPassword>
    {
        public UserValidation()
        {
            RuleFor(p=>p.UserName).MinimumLength(3);
            RuleFor(p=>p.UserName).NotEmpty();
            RuleFor(p=>p.Password).MinimumLength(3);
            RuleFor(p=>p.Password).NotEmpty();
            RuleFor(p=>p.PassCategory).NotEmpty();
            RuleFor(p=>p.Url).NotEmpty();
        }
    }
}
