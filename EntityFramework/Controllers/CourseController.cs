using EntityFramework.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Controllers
{
    public class CourseController : Controller
    {
        private readonly DataContext _dataContext;
        public CourseController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _dataContext.Courses.ToListAsync());
        }

        [HttpGet]
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

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var course = await _dataContext.Courses.FindAsync(id);

            if (course == null)
                return NotFound();

            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Course course)
        {
            if (id != course.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _dataContext.Update(course);
                    await _dataContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_dataContext.Courses.Any(s => s.Id == course.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction("Index");
            }

            return View(course);
        }


    }
}
