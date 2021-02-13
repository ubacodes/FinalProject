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
            //Data Transformation Object
            ProductTest();
            //IoC 
            //CategoryTest();
        }
        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal()); // hangi veritabanını kullacağımızı belirterek bir tane ürünyönetimi nesnesi oluşturduk

            var result = productManager.GetProductDetails();

            if (result.Success)
            {
                foreach (var product in productManager.GetProductDetails().Data)
                {
                    Console.WriteLine(product.ProductName + "/" + product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            //ben ekledim
            //    foreach (var product in productManager.GetAll().Data)
            //    {
            //        Console.WriteLine("Tüm Ürünler: " + product.ProductName);
            //    }
            //    // aşağıdakileri ben ekledim
            //    foreach (var product in productManager.GetAllByCategoryId(1).Data)
            //    {
            //        Console.WriteLine("Ürünlerin KategoriId'leri: " + product.CategoryId + " Ürünlerin İsimleri: " + product.ProductName);
            //    }

            //    foreach (var product in productManager.GetByUnitPrice(15, 25).Data)
            //    {
            //        Console.WriteLine("Ürünlerin Birim Fiyatları: " + product.UnitPrice + " Ürünülerin İsimleri: " + product.ProductName);
            //    }
        }
    }
}