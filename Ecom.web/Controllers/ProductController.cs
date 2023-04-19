using Ecom.web.Data;
using Ecom.web.Models;
using Ecom.web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ecom.web.Controllers
{
    public class ProductController : Controller
    {
        private EcomDbContext _dbContext;
        private IProductService _productService;
        public ProductController(EcomDbContext dbContext,IProductService productService)
        {
            _productService = productService;
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult index()
        {
            List<ProductModel> lst = _productService.GetAllProducts();

            //IList<ProductModel> list = _dbContext.Product.Where(X => !X.IsDeleted).ToList();
            return View(lst);
        }
        [HttpGet]
        public IActionResult Create()
        {
            List<CategoryModel> cats = _dbContext.Category.Where(x => x.IsActive && !x.IsDeleted).ToList();
            List<SelectListItem> lst = cats.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            ViewBag.Categories = lst;
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductModel model)
        {
            model.CreatedOn = DateTime.Now;
            model.IsDeleted = false;

            _productService.AddProduct(model);
            //_dbContext.Product.Add(model);
            //_dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            ProductModel pro = _dbContext.Product.FirstOrDefault(x=> x.Id == id);
            if(pro == null)
            {
                return RedirectToAction("Index");
            }
            return View(pro);
        }
        [HttpPost]
        public IActionResult Update(ProductModel model)
        {
            ProductModel pro = _dbContext.Product.FirstOrDefault(x => x.Id == model.Id);
            if (pro != null)
            {
                pro.Name = model.Name;
                pro.Description = model.Description;
                pro.IsActive = model.IsActive;
                pro.Price = model.Price;
                pro.CategoryId = model.CategoryId;
                pro.UpdatedOn = DateTime.Now;
                _dbContext.Product.Update(pro);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            ProductModel pro = _dbContext.Product.FirstOrDefault(x => x.Id == id);
            if (pro != null)
            {
                pro.IsDeleted = true;
                pro.UpdatedOn = DateTime.Now;
                _dbContext.Product.Update(pro);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("index");
        }
    }
}
