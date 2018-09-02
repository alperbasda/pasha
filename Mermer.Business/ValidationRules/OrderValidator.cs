using FluentValidation;
using Mermer.Entity.Concrete;

namespace Mermer.Business.ValidationRules
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(s => s.ProductId).NotEmpty().WithErrorCode("Ürün seçimi yapılmadı!!!");
            RuleFor(s => s.CustomerFirstName).NotEmpty().WithErrorCode("Lütfen isminizi giriniz!!!");
            RuleFor(s => s.CustomerLastName).NotEmpty().WithErrorCode("Lütfen soyadınızı giriniz!!!");
            RuleFor(s => s.CustomerMail).NotEmpty().WithErrorCode("Lütfen mail adresinizi giriniz!!!");
            RuleFor(s => s.CustomerMail).Must(s=>s.Contains("@")).WithErrorCode("Lütfen mail adresinizi doğru giriniz!!!");
            RuleFor(s => s.CustomerTelephone).Length(11, 11).WithErrorCode("Telefonunuzu 11 haneli olarak giriniz!!!");
            RuleFor(s => s.ProductCount).NotEmpty().WithErrorCode("Lütfen ürün miktarini giriniz!!!");
        }
    }
}