using LMS.Data;
using LMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMS.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var studentInfo = _context.Students.ToList();
            return View(studentInfo);
        }


        [HttpGet]
        public IActionResult AddEdit(int id)
        {
            Student student = new Student();

            if (id > 0)
            {
                student = _context.Students.FirstOrDefault(x => x.Id == id);
            }

            return View(student);
        }

        //[Authorize(Roles = "ADMIN")]
        [HttpPost]
        public IActionResult AddEdit(Student student)
        {
            if (student.Id == 0)
            {
                _context.Add(student);
                _context.SaveChanges();
            }
            else
            {

                var studentinfo = _context.Students.FirstOrDefault(x => x.Id == student.Id);

                studentinfo.FullName = student.FullName;
                studentinfo.RollNo = student.RollNo;
                studentinfo.Class = student.Class;
                studentinfo.Email = student.Email;
                studentinfo.PhoneNumber = student.PhoneNumber;
                studentinfo.Address = student.Address;
                studentinfo.IsActive = student.IsActive;

                _context.Update(studentinfo);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }


        //[Authorize(Roles = "ADMIN")]
        public IActionResult Remove(int id)
        {
            var studentinfo = _context.Students.FirstOrDefault(x => x.Id == id);
            _context.Remove(studentinfo);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Detail(int id)
        {
            var studentinfo = _context.Students.FirstOrDefault(x => x.Id == id);
            return View(studentinfo);
        }
    }
}
