using FluentValidation;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            // doğrulama kuralları = validatorlar buraya yazılıyor bir constructor metot içerisine

            RuleFor(p => p.ProductName).MinimumLength(2);   // ProductName 'in minimum uzunluğu 2 karakter olmalıdır. Bunları businessda yazmıyoruz asla
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0); // 0 dan büyük olmalı  // ne işe yarıyor bak diğer metotlarında
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);  // product'un categoryid si 1 olduğunda unitprice'ı en az 10 olmalı
            RuleFor(p => p.ProductName).Must(StarWithA).WithMessage("Ürünler A harfi ile başlamalı");
        }

        private bool StarWithA(string productName)   // true yada false döner // false dönerse patlar
        {
            return productName.StartsWith("A");
        }
    }
}
