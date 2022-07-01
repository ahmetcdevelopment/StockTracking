using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<Task<List<Product>>> GetAll();
        IDataResult<Task<List<Product>>> GetAllByCategoryId(int id);
        IDataResult<Task<List<Product>>>GetAllByBrandId(int id);
        IResult Add(Product product);
        IDataResult<Task<Product>> GetById(int productId);
        Task<IDataResult<List<ProductDetailDto>>> GetProductDetails();
    }
}
