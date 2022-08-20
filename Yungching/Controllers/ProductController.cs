using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yungching.Models;
using Yungching.ViewModels;

namespace Yungching.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly YungchingDemoContext _dbcontext;
        private readonly IMapper _mapper;

        public ProductController(YungchingDemoContext dbcontext,IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        [Route("api/Product/getAllProduct")]
        [HttpGet]
        public List<Product> getAllProduct() 
        {
            var products = _dbcontext.Products.ToList();
            return products;
        }

        [Route("api/Product/addNewProduct")]
        [HttpPost]
        public Status addNewProduct(AddProduct addProduct) 
        {
            Status status = new Status();
            try
            {
                _dbcontext.Products.Add(new Product
                {
                    ProductName = addProduct.ProductName,
                    ProductPrice = addProduct.ProductPrice,
                    ProductDetail = addProduct.ProductDetail
                });
                _dbcontext.SaveChanges();
                status.Msg = "新增成功";
                return status;
            }
            catch
            {
                status.Msg = "新增失敗";
                return status;
            }
        }

        [Route("api/Product/editProduct")]
        [HttpPut]
        public Status editProduct(EditProduct editProduct) 
        {
            Status status = new Status();
            try
            {
                var product = _dbcontext.Products.Where(x => x.ProductId == editProduct.ProductId).FirstOrDefault();
                _dbcontext.Products.Update(_mapper.Map(editProduct, product));
                _dbcontext.SaveChanges();
                status.Msg = "更新成功";
                return status;
            }
            catch 
            {
                status.Msg = "更新失敗";
                return status;
            }
        }

        [Route("api/Product/deleteProduct")]
        [HttpDelete]
        public Status deleteProduct(int productId) 
        {
            Status status = new Status();
            try
            {
                var product = _dbcontext.Products.FirstOrDefault(x => x.ProductId == productId);
                _dbcontext.Remove(product);
                _dbcontext.SaveChanges();
                status.Msg = "刪除成功";
                return status;
            }
            catch 
            {
                status.Msg = "刪除失敗";
                return status;
            }
        }
    }
}
