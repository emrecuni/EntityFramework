using EntityFramework.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Controllers
{
    public class CourseRegisterController : Controller
    {
        private readonly DataContext _dataContext;

        public CourseRegisterController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IActionResult> Index()
        {
            var courseRegisters = await _dataContext.CourseRegisters.ToListAsync();

            return View(courseRegisters);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Students = new SelectList(await _dataContext.Students.ToListAsync(),"StudentId","FullName");
            ViewBag.Courses = new SelectList(await _dataContext.Courses.ToListAsync(),"CourseId","Title");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseRegister register)
        {
            register.RegisterDate = DateTime.Now;
            _dataContext.CourseRegisters.Add(register); 
            await _dataContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
