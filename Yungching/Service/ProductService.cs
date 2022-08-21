using AutoMapper;
using Yungching.Interface;
using Yungching.Models;
using Yungching.ViewModels;

namespace Yungching.Service
{
    public class ProductService : IProductService
    {
        private readonly YungchingDemoContext _dbcontext;
        private readonly IMapper _mapper;

        public ProductService(YungchingDemoContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

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

        public Status deleteProduct(DeleteProduct deleteproduct)
        {
            Status status = new Status();
            try
            {
                var product = _dbcontext.Products.FirstOrDefault(x => x.ProductId == deleteproduct.ProductId);
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

        public List<Product> getAllProduct()
        {
            var products = _dbcontext.Products.ToList();
            return products;
        }
    }
}
