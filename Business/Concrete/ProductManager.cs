﻿using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new Result(true,"Ürün Eklendi.");  // döndürülecek değeri Result nesnesi oluştur dedik.
        }

        public List<Product> GetAll()
        {
            // iş kodları
            // iş kodlarından geçtiğini varsayarak aşağıdan devam ediyoruz
            // kural : bir iş sınıfı başka sınıfları newlemez etmez

            return _productDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException(); // burayı ekleyeceğim
        }

        Product IProductService.GetById(int productId)
        {
            return _productDal.Get(p => p.ProductId == productId);
        }
    }
}
