using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class ProductManager : IProductService
{
    IProductDal _productDal;
    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }


    [CacheRemoveAspect("IProductService.Get")]
    [SecuredOperation("color.add.admin")]
    [ValidationAspect(typeof(ProductValidator))]
    public IResult Add(Product product)
    {
        IResult result = BusinessRules.Run(CheckIfProductNameExists(product.ProductStatusName));
        if(result != null) 
        {
            return result;
        }
        _productDal.Add(product);
        return new SuccessResult(Messages.Added);
    }

    [CacheRemoveAspect("IProductService.Get")]
    public IResult Delete(Product product)
    {
        IResult result = BusinessRules.Run(CheckIfProductNotExists(product.ProductStatusId));
        if (result != null)
        {
            return new ErrorResult(Messages.InvalidDelete);
        }
        _productDal.Delete(product);
        return new SuccessResult(Messages.Deleted);
    }

    [PerformanceAspect(5)]
    [CacheAspect]
    public IDataResult<List<Product>> GetAll()
    {
        return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.Listed);
    }

    [PerformanceAspect(5)]
    [CacheAspect]
    public IDataResult<Product> GetById(int id)
    {
        return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductStatusId == id), Messages.Listed);
    }

    [CacheRemoveAspect("IProductService.Get")]
    [ValidationAspect(typeof(ValidationAspect))]
    public IResult Update(Product product)
    {
        IResult result = BusinessRules.Run(CheckIfProductNotExists(product.ProductStatusId));
        if (result != null)
        {
            return new ErrorResult(Messages.InvalidUpdate);
        }
        _productDal.Update(product);
        return new SuccessResult(Messages.Updated);
    }

    private IResult CheckIfProductNameExists(string productName)
    {
        var result = _productDal.GetAll(P => P.ProductStatusName == productName).Any();
        if(!result)
        {
            return new ErrorResult(Messages.ProductNameAlreadyExists);
        }
        return new SuccessResult();
    }

    private IResult CheckIfProductNotExists(long productId)
    {
        var result = _productDal.GetAll(p => p.ProductStatusId == productId).Any();
        if(!result)
        {
            return new ErrorResult(Messages.ProductNotExists);
        }
        return new SuccessResult();
    }
}
