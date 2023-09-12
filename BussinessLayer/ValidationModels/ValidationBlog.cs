using Entities;
using FluentValidation;

namespace BussinessLayer.ValidationModels
{
    public class ValidationBlog : AbstractValidator<TBLBlog>
    {
        public ValidationBlog()
        {
            RuleFor(x => x.BlogName).MaximumLength(50).MinimumLength(10).WithMessage("10 ile 50 karakter arası şifre girebilirsiniz.");

            RuleFor(x => x.BlogName).MinimumLength(10).WithMessage("Minimum 10 Karakter Girilebilir.");
        }
    }
}
