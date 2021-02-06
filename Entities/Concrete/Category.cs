using Core.Entities; // aynı katmanda da olsa başka bir klasördeki elemanı kullanacağını belirtmen gerekiyor
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Category : IEntity
    {
        
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
