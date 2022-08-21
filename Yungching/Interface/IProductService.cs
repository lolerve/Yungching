using Yungching.Models;
using Yungching.ViewModels;

namespace Yungching.Interface
{
    public interface IProductService
    {
        List<Product> getAllProduct();
        Status addNewProduct(AddProduct addProduct);
        Status editProduct(EditProduct editProduct);
        Status deleteProduct(DeleteProduct deleteproduct);
    }
}
