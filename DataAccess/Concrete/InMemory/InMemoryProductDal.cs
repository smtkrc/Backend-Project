using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> {
            new Product{ProductID=1,CategoryID=1,ProductName="Dolap",UnitPrice=1500, UnitsInStock=10},
            new Product{ProductID=2,CategoryID=1,ProductName="Bardak",UnitPrice=15, UnitsInStock=3},
            new Product{ProductID=3,CategoryID=2,ProductName="Kamera",UnitPrice=500, UnitsInStock=15},
            new Product{ProductID=4,CategoryID=2,ProductName="Mouse",UnitPrice=150, UnitsInStock=6},
            new Product{ProductID=5,CategoryID=2,ProductName="Klavye",UnitPrice=85, UnitsInStock=1},
            };
        }
        public void Add(Product Product)
        {
            _products.Add(Product);
        }

        public void Delete(Product Product)
        {
            Product productToDelete = _products.SingleOrDefault(p => p.ProductID == Product.ProductID);
            _products.Remove(productToDelete);
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
            return _products;
        }

        public List<Product> GetAllByCategory(int CategoryId)
        {
            return _products.Where(p => p.CategoryID == CategoryId).ToList();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product Product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductID == Product.ProductID);
            productToUpdate.ProductName = Product.ProductName;
            productToUpdate.CategoryID = Product.CategoryID;
            productToUpdate.UnitPrice = Product.UnitPrice;
            productToUpdate.UnitsInStock = Product.UnitsInStock;
        }
    }
}
