using Core.DataAccess.EntitiyFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, StockTrackingContext>, IProductDal
    {
        //public List<ProductDetailDto> GetProdductDetails()
        //{
        //    using (StockTrackingContext context=new StockTrackingContext())
        //    {
        //        var result = from p in context.Products
        //                     join c in context.Categories
        //                     on p.CategoryId equals c.CategoryId
        //                     select new ProductDetailDto
        //                     {
        //                         ProductId = p.ProductId,
        //                         ProductName = p.ProductName,
        //                         CategoryName = c.CategoryName,
        //                         Barcode = p.Barcode,
        //                     };
        //        return result.ToList();
        //    }
        //}

        public async Task<List<ProductDetailDto>> GetProdductDetails()
        {
            using (StockTrackingContext context = new StockTrackingContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 Barcode = p.Barcode,
                             };
                return await result.ToListAsync();
            }
        }
    }
}
