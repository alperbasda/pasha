using FluentValidation;
using Mermer.Entity.Concrete;

namespace Mermer.Business.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(s => s.CategoryId).NotEmpty().WithErrorCode("Lütfen kategori seçiniz!!!");
            RuleFor(s => s.Description).NotEmpty().WithErrorCode("Lütfen ürün için açıklama giriniz!!!");
            RuleFor(s => s.Name).NotEmpty().WithErrorCode("Lütfen ürünün adını giriniz!!!");
        }   
    }
}