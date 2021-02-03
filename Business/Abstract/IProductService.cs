using Entities.Concrete; // Entities katmanına erişim için kullandık yine aynı şekilde DataAccess ve Entities add proje referanse ettik
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetAllByCategoryId(int id);
        List<Product> GetByUnitPrice(decimal min, decimal max);
    }
}
