using DataAccess.Abstract;
using Entities.Concrete; // Entities katmanını using edebilmek için DataAccess katmanında Dependencies'a Add project referance to diyerek Entities katmanını ekliyoruz
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    // interface metotları kendisi default olarak public değildir yalnız elemanları default olarak publictir
    public interface IProductDal : IEntityRepository<Product> // IEntityRepository interface'ini Product class'ı için yapılandırdık artık o interface'i Product cinsine göre kullanabilirsin
    {
    }
}
