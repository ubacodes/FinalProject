using DataAccess.Abstract; // IProductDal interface'ini kullanabilmek için using ekledik
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq; // LINQ' u kullanabilmek için using ettik
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products; // InMemoryProductDal class'ı içerisinde global bir değişken 
        public InMemoryProductDal() // Constructor
        {
            // bir veritabanından gelen bir ürün listesi gibi simule ediyoruz
            _products = new List<Product> { 
                new Product {ProductId = 1, CategoryId = 1, ProductName = "Bardak", UnitPrice = 50, UnitsInStock = 15},
                new Product {ProductId = 2, CategoryId = 2, ProductName = "Mouse", UnitPrice = 700, UnitsInStock = 10},
                new Product {ProductId = 3, CategoryId = 2, ProductName = "Kamera", UnitPrice = 1350, UnitsInStock = 5},
                new Product {ProductId = 4, CategoryId = 2, ProductName = "Telefon", UnitPrice = 2700, UnitsInStock = 2},
                new Product {ProductId = 5, CategoryId = 1, ProductName = "Masa", UnitPrice = 500, UnitsInStock = 10},
            };
        }

        // interface'den implement ediyoruz
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            // LINQ - Language Integrated Query

            Product productToDelete = null;
            productToDelete = _products.SingleOrDefault(p =>p.ProductId == product.ProductId); // her ürün için tek tek git bak bakalım verilen ürün ile veritabanındaki ürünid si eşleşiyor mu ?
            // yukarıda ki p takma isimdir
            // SingleOrDefault bir metottur.
            _products.Remove(productToDelete); // silinecekürün adlı değerin içerisindeki referans numarasına sahip ürünü veritabanından sil

            //LINQ yoksa aşağıdaki kodlar 
           // Product productToDelete = null; // referans verme şuan
           // foreach (var p in _products)
           // {
            //    if(product.ProductId == p.ProductId)  // ürünler içerisinde productid alanı metota verilen ürünün productid si ile eşit ise
            //    {
            //        productToDelete = p; // referans numarasını silinecekürünün referansına eşitle
            //    }
           // }

        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList(); // where koşulu içerisindeki şartlara uyan bütün elemanları yeni bir liste haline getirip onu döndürür
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            // gönderdiğim ürün id'sine sahip olan listedeki (veritabanındaki) ürünü bul 
            Product productToUpdate = null;
            productToUpdate = _products.SingleOrDefault(u => u.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;

            // referans değerini aldıktan sonra o referans adresindeki değerin sütünlarını bize product olarak metota parametre ile aldığımız değerleri güncelliyoruz.

        }



    }
}
