using Entities;
using FluentValidation;

namespace BussinessLayer.ValidationModels
{
    public class ValidationCategories : AbstractValidator<TBLCategories>
    {
        public ValidationCategories()
        {
            RuleFor(x => x.CategoryName).MaximumLength(50).MinimumLength(10).WithMessage("10 ile 50 karakter arası şifre girebilirsiniz.");
        }
    }
}
