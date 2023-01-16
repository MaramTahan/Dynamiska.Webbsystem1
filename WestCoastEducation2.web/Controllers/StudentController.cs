using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WestCoastEducation2.web.Data;

namespace WestCoastEducation2.web.Controllers;

    [Route("[Student]")]
    public class StudentController : Controller
    {
  private readonly westcoasteducationContext _context;
        public StudentController(westcoasteducationContext context){
            _context = context;
        }

        public async Task <IActionResult> Index()
        {
            var student = await _context.studentData.ToListAsync();
            return View("Index", student);
        }
    }
