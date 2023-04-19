using Ecom.web.Data;
using Ecom.web.Models;

namespace Ecom.web.Services
{
    public class ProductService : IProductService
    {
        private EcomDbContext _dbContext;
        public ProductService(EcomDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddProduct(ProductModel model) 
        {
            _dbContext.Product.Add(model);
            _dbContext.SaveChanges();
        }
        public List<ProductModel> GetAllProducts()
        {
            List<ProductModel> lst = (from p in _dbContext.Product
                                      join c in _dbContext.Category on p.CategoryId equals c.Id
                                      where p.IsActive && !p.IsDeleted
                                      select new ProductModel
                                      {
                                          Id = p.Id,
                                          Name = p.Name,
                                          IsActive = p.IsActive,
                                          IsDeleted = p.IsDeleted,
                                          Description = p.Description,
                                          CreatedOn = p.CreatedOn,
                                          UpdatedOn = p.UpdatedOn,
                                          Price = p.Price,
                                          CategoryId = p.CategoryId,
                                          CategoryName = c.Name,
                                      }).ToList();
            return lst;
            //Microsoft.AspNetcore.Identity
            //''EntityFramework
        }
    }
        
}
