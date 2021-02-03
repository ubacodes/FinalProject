using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal()); // hangi veritabanını kullacağımızı belirterek bir tane ürünyönetimi nesnesi oluşturduk

            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }
            // aşağıdakileri ben ekledim
            foreach (var product in productManager.GetAllByCategoryId(1))
            {
                Console.WriteLine(product.CategoryId+product.ProductName);
            }

            foreach (var product in productManager.GetByUnitPrice(15,25))
            {
                Console.WriteLine(product.UnitPrice+product.ProductName);
            }

        }
    }
}
