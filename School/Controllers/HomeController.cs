using Microsoft.AspNetCore.Mvc;
using School.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace School.Controllers
{
    public class HomeController : Controller
    {
        private readonly SchoolDbContext _context;

        public HomeController(SchoolDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
           
            //var students = await _context.Students.ToListAsync();

            var TestObject = (from student in _context.Students
                             from teacher in _context.TeacherDetails
                             where student.Class == teacher.Class
                             select new StudentTeacherViewModel
                             {
                                 class_room = student.Class,
                                 teacher_name = teacher.Name,
                                 student_name = student.Name,
                             }).ToList();

            return View(TestObject);
        }

    }
}