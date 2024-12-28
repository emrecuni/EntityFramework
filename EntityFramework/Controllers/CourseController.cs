using EntityFramework.Data;
using Microsoft.AspNetCore.Mvc;

namespace EntityFramework.Controllers
{
    public class CourseController : Controller
    {
        private readonly DataContext _dataContext;
        public CourseController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Course model)
        {
            _dataContext.Courses.Add(model);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
