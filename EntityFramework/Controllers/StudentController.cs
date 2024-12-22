using EntityFramework.Data;
using Microsoft.AspNetCore.Mvc;

namespace EntityFramework.Controllers
{
    public class StudentController : Controller
    {
        private readonly DataContext _dataContext;

        public StudentController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student model)
        {
            _dataContext.Students.Add(model);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction("Index","Home");
        }
    }
}
