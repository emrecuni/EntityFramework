using EntityFramework.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Controllers
{
    public class TeacherController : Controller
    {
        private readonly DataContext _dataContext;
        public TeacherController(DataContext dataContext)
        {
            _dataContext = dataContext; 
        }

        public async Task<IActionResult> Index()
        {
            return View(await _dataContext.Teachers.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Teacher model)
        {
            _dataContext.Teachers.Add(model);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var teacher = await _dataContext.Teachers
                //.Include(s => s.CourseRegisters)
                //.ThenInclude(s => s.Course)
                .FirstOrDefaultAsync(s => s.TeacherId == id);
            if (teacher == null)
                return NotFound();

            return View(teacher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Teacher teacher)
        {
            if (id != teacher.TeacherId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _dataContext.Update(teacher);
                    await _dataContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_dataContext.Teachers.Any(s => s.TeacherId == teacher.TeacherId))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction("Index");
            }

            return View(teacher);
        }

    }
}
