using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yungching.Interface;
using Yungching.Models;
using Yungching.ViewModels;

namespace Yungching.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productervice;

        public ProductController(IProductService productervice)
        {
            _productervice = productervice;
        }

        [Route("api/Product/getAllProduct")]
        [HttpGet]
        public List<Product> getAllProduct() 
        {
            return _productervice.getAllProduct();
        }

        [Route("api/Product/addNewProduct")]
        [HttpPost]
        public Status addNewProduct(AddProduct addProduct) 
        {
            return _productervice.addNewProduct(addProduct);
        }

        [Route("api/Product/editProduct")]
        [HttpPut]
        public Status editProduct(EditProduct editProduct) 
        {
            return _productervice.editProduct(editProduct);
        }

        [Route("api/Product/deleteProduct")]
        [HttpDelete]
        public Status deleteProduct(DeleteProduct deleteproduct) 
        {
            return _productervice.deleteProduct(deleteproduct);
        }
    }
}
