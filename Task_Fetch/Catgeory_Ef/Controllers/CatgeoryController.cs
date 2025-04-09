using Catgeory_Ef.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catgeory_Ef.Controllers
{
    public class CatgeoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CatgeoryController(ApplicationDbContext context)
        {
            _context = context;
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
