using Entities.Concrete;
using Entities.DTOs;
using GeneralClass.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllBycategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IResult add(Product product);
        IResult Update(Product product);
        IDataResult<Product> GetById(int productId);
    }
}
