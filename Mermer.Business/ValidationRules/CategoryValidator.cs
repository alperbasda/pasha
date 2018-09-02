using FluentValidation;
using Mermer.Entity.Concrete;

namespace Mermer.Business.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(s => s.Name).NotEmpty().WithErrorCode("Kategori adı boş bırakılamaz!!!");
        }
    }
}