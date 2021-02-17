using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using Business.Abstract;
using Business.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]   // Bu isteği yaparken bu insanlar bize nasıl ulaşması gerektiğini belirtiyor
    [ApiController]    // bir imzalama çeşitidir ProductsController'ın bir APIController olduğunu ve .NET'in bu class'ı ona göre yapılandırması gerektiğini belirtir
    public class ProductsController : ControllerBase  
    {
        // Loosely coupled = gevşek bağımlılık
        // naming convertion = isimlendirme standartları // field değişkenlerde _ ile başlanır
        // IoC Container = Inversion of control = değişimin kontrolu anlamına geliyor  // bellekte referansların barındığı bir alan(liste gibi) demek yani 

        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            // Dependency chain-- bağımlılık zinciri var IProductService bir ProductManager'a ihtiyaç duyuyor ProductManager da bir EfProductDal olan IProductDal yapısına ihtiyaç duyuyor
            var result = _productService.GetAll();
            if (result.Success == true)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }

        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int productId)
        {
            var result = _productService.GetById(productId);
            if (result.Success == true)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }


        [HttpPost("add")]
        public IActionResult Add(Product product) // postmandan v.s.'den gönderdiğin ürünü bu parametreye yerleştir ben onu ekleyeceğim 
        {
            var result = _productService.Add(product);
            if (result.Success == true)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }


    }
}
