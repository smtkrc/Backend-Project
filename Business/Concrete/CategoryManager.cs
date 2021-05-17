﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using GeneralClass.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<List<Category>>  GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        public IDataResult<Category>  GetById(int CategoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.CategoryId == CategoryId));
        }
    }
}
