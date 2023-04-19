using Ecom.web.Models;

namespace Ecom.web.Services
{
    public interface IProductService
    {
        void AddProduct(ProductModel model);
        List<ProductModel> GetAllProducts();

    }
}
