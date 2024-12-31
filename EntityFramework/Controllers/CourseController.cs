using EntityFramework.Data;
using EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var courses = await _dataContext.Courses
                .Include(c => c.Teacher)
                .ToListAsync();
            return View(courses);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Teachers = new SelectList(await _dataContext.Teachers.ToListAsync(),"TeacherId", "FullName");
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

            var course = await _dataContext.Courses
                .Include(c => c.CourseRegisters)
                .ThenInclude(c => c.Student)
                .Select(c => new CourseViewModel
                {
                    CourseId = c.CourseId,
                    Title = c.Title,
                    TeacherId = c.TeacherId,
                    CourseRegisters = c.CourseRegisters
                })
                .FirstOrDefaultAsync(c => c.CourseId == id);

            if (course == null)
                return NotFound();

            ViewBag.Teachers = new SelectList(await _dataContext.Teachers.ToListAsync(), "TeacherId", "FullName");
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, CourseViewModel course)
        {
            if (id != course.CourseId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _dataContext.Update(new Course() { CourseId = course.CourseId, Title = course.Title, TeacherId = course.TeacherId});
                    await _dataContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_dataContext.Courses.Any(s => s.CourseId == course.CourseId))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction("Index");
            }

            return View(course);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var course = await _dataContext.Courses.FindAsync(id);

            if (course == null)
                return NotFound();

            return View(course);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            var course = await _dataContext.Courses.FirstAsync(s => s.CourseId == id);
            if (course == null)
                return NotFound();

            _dataContext.Courses.Remove(course);
            await _dataContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
