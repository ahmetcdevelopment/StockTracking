using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (product.ProductName.Length < 2)
                return new ErrorResult(Messages.Failed);
            _productDal.AddAsync(product);
            return new Result(true,Messages.Added);
        }

        public IDataResult<Task<List<Product>>> GetAll()
        {
            return new SuccessDataResult<Task<List<Product>>>(_productDal.GetAllAsync(),Messages.Listed);
        }

        public IDataResult<Task<List<Product>>> GetAllByBrandId(int id)
        {
            return new SuccessDataResult<Task<List<Product>>>(_productDal.GetAllAsync(p => p.BrandId == id));
        }

        public  IDataResult<Task<List<Product>>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<Task<List<Product>>>(_productDal.GetAllAsync(p=>p.CategoryId==id));
        }

        public  IDataResult<Task<Product>> GetById(int productId)
        {
            return  new SuccessDataResult<Task<Product>>(_productDal.GetAsync(p=>p.ProductId==productId));
        }

        public async Task<IDataResult<List<ProductDetailDto>>> GetProductDetails()//Task<IDataResult<List<ProductDetailDto>>>
        {
            return new SuccessDataResult<List<ProductDetailDto>>(await _productDal.GetProdductDetails());
        }
    }
}
