using Ecom.web.Data;
using Ecom.web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.web.Controllers
{
    [Authorize(Roles ="Admin")]
    public class CategoryController : Controller
    {
        private EcomDbContext _dbContext;
        public CategoryController(EcomDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            IList<CategoryModel> list = _dbContext.Category.Where(X=>!X.IsDeleted).ToList();
            return View(list);

        }
        
        [HttpGet]
        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public  IActionResult Create(CategoryModel model)
        {
            model.CreatedOn = DateTime.Now;
            model.IsDeleted = false;

            _dbContext.Category.Add(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            CategoryModel cat = _dbContext.Category.FirstOrDefault(x => x.Id == id);
            if(cat == null)
            {
                return RedirectToAction("Index");
            }
            return View(cat);
        }
        [HttpPost]

        public IActionResult Update(CategoryModel model)
        {
            CategoryModel dbcat = _dbContext.Category.FirstOrDefault(x => x.Id == model.Id);
            if(dbcat != null)
            {
                dbcat.Name = model.Name;
                dbcat.Description = model.Description;
                dbcat.IsActive = model.IsActive;
                dbcat.UpdatedOn = DateTime.Now;
                _dbContext.Category.Update(dbcat);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            CategoryModel cat = _dbContext.Category.FirstOrDefault(x => x.Id == id);
            if (cat != null)
            {
                cat.IsDeleted = true;
                cat.UpdatedOn = DateTime.Now;
                _dbContext.Category.Update(cat);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("index");
        }
    }
}
