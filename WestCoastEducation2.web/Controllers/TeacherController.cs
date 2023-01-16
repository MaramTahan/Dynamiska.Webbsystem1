
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WestCoastEducation2.web.Data;

namespace WestCoastEducation2.web.Controllers
{
    [Route("[Teacher]")]
    public class TeacherController : Controller
    {
        private readonly westcoasteducationContext _context;
        public TeacherController(westcoasteducationContext context){
            _context = context;
        }


        public async Task <IActionResult> Index()
        {
           var teacher = await _context.teacherData.ToListAsync();
            return View("Index", teacher);
        }

    }
}