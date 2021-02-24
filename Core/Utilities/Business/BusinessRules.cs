using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        // iş kurallarını bu yapıyı kullanarak buraya yolluyoruz burada IResult dizisi oluşturup içerisine alıyor ve programı tüm o yolladığımız iş kurallarını gezerek çalıştırıp 
        // hata varsa logic 'i yani iş kuralını geri döndürüyor eğer başarılı ise geriye hata yollamasına gerek olmadığından null değeri yolluyor
        
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }
            return null;
        }
    }
}
