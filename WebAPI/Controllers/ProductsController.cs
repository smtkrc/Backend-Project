using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]   // = ATTRIBUTE(Özellik,Bilgi)
    public class ProductsController : ControllerBase
    {
        //Loosely coupled - gevşek bağımlılık 
        IProductService _productservice;

        public ProductsController(IProductService productservice)
        {
            _productservice = productservice;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            // Dependency chain --
            //IProductService productservice = new ProductManager(new EfProductDal());
            
            var result = _productservice.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productservice.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productservice.add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
