using Catgeory_Ef.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Catgeory_Ef.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var Products = _context.products
                .Include(p => p.Subcategory)
                .ThenInclude(s => s.Category)
                .ToList();

            return View(Products);
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = _context.categories.ToList();
            return View();
        }


        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {

                ViewBag.Categories = _context.categories.ToList();
                return View(product);
            }

            var subcategory = _context.subcategories
                .Include(s => s.Category)
                .FirstOrDefault(s => s.Id == product.SubcategoryId);

            if (subcategory != null)
            {
                product.Name = $"{subcategory.Category.Name} {subcategory.Name}";
                _context.products.Add(product);
                _context.SaveChanges();


                return RedirectToAction("Index");
            }

            ViewBag.Categories = _context.categories.ToList();
            return View(product);
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _context.products.Find(id);
            if (product == null) return NotFound();
            ViewBag.Categories = _context.categories.ToList();
            return View(product);
        }


        [HttpPost]
        public IActionResult Edit(Product product)
        {

            var product1 = _context.products.Find(product.Id);
            product1.Id = product.Id;
            product1.Name = product.Name;
            product1.Price = product.Price;
            product1.Subcategory = product.Subcategory;

            _context.SaveChanges();
            return RedirectToAction("Index");



        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _context.products.Include(p => p.Subcategory).ThenInclude(s => s.Category).FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _context.products.Find(id);
            if (product != null)
            {
                _context.products.Remove(product);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var product = _context.products.Include(p => p.Subcategory).ThenInclude(s => s.Category).FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpGet]
        public JsonResult GetSubcategories(int categoryId)
        {
            var subcategories = _context.subcategories
                .Where(s => s.CategoryId == categoryId)
                .ToList();
            return Json(subcategories);
        }


    }
}
