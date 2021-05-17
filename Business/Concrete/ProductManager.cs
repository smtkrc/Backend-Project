using Business.Abstract;
using Business.BusinessAspect.Aspect;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using GeneralClass.Aspects.Autofac.Caching;
using GeneralClass.Aspects.Autofac.Validation;
using GeneralClass.CrossCuttingConcerns.Validation;
using GeneralClass.Utilities.Business;
using GeneralClass.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        //Business Code -- iş kodlarına uygunluk demek .(Mesela bankanın verdiği krediye müşterinin uygun olup olmadığını sorgulama gibi.)(İş kurallar)
        //Validation -- Doğrulama(Mesela kullanıcı ad girerken bize belirlediği şartlar gibi)(Verinin yapısı)


        IProductDal _IProductDal;
        ICategoryService _categoryservice;

        public ProductManager(IProductDal ıProductDal, ICategoryService categoryService)
        {
            _IProductDal = ıProductDal;
            _categoryservice = categoryService;
        }

        [SecuredOperation("admin,editor")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult add(Product product)
        {

            IResult Result = BusinessRules.Run(CheckOfProductNameExists(product.ProductName),
                  CheccIfCategoryProductCountOfCategoryCorrect(product.CategoryID),
                  CheckIfCategoryLimitExceded());

            if (Result != null)
            {
                return Result;
            }

            _IProductDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }


        [CacheAspect] //Key= Cashe e verdiğimiz isim diyebiliriz. , Value 
        public IDataResult<List<Product>> GetAll()
        {
            //Business Code
            //Yetkisi var mı ?
            if (DateTime.Now.Hour == 15)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_IProductDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllBycategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_IProductDal.GetAll(p => p.CategoryID == id), Messages.ProductListed);
        }
        [CacheAspect]
      
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_IProductDal.Get(p => p.ProductID == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_IProductDal.GetAll(p => p.UnitPrice <= max && p.UnitPrice >= min));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {

            return new SuccessDataResult<List<ProductDetailDto>>(_IProductDal.GetProductDetails());
        }

        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }

        private IResult CheccIfCategoryProductCountOfCategoryCorrect(int categoryıd)
        {
            var result = _IProductDal.GetAll(p => p.CategoryID == categoryıd).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }
        private IResult CheckOfProductNameExists(string productname)
        {
            var result = _IProductDal.GetAll(p => p.ProductName == productname).Any();
            if (result == true)
            {
                return new ErrorResult(Messages.ProductNameErrorExists);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryservice.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }
    }
}
