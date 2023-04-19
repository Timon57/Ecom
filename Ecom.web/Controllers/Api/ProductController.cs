using Ecom.web.Data;
using Ecom.web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private EcomDbContext _dbContext;
        public ProductController(EcomDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<ProductModel> Get()
        {
            List<ProductModel> products = _dbContext.Product.ToList();
            return products;
        }
    }
}
