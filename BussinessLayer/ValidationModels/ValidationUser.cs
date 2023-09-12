using Entities;
using FluentValidation;

namespace BussinessLayer.ValidationModels
{
    public class ValidationUser : AbstractValidator<TBLUser>
    {
        public ValidationUser()
        {
            RuleFor(x=> x.Passwords).MaximumLength(50).MinimumLength(10).WithMessage("10 ile 50 karakter arası şifre girebilirsiniz.");

            RuleFor(x => x.Email).MaximumLength(50).MinimumLength(10).WithMessage("10 ile 50 karakter arası şifre girebilirsiniz.");
        }
    }
}
