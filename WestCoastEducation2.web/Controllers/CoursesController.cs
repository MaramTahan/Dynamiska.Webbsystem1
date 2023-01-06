using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WestCoastEducation2.web.Data;


namespace WestCoastEducation2.web.Controllers
{
    [Route("Courses")]
    public class CoursesController : Controller
    {
  private readonly westcoasteducationContext _context;
  public CoursesController(westcoasteducationContext context)
  {
   this._context = context;
  }

  ////url: https://localhost:7140/Courses/index
  public async Task<IActionResult> Index()
        {
            var courses = await _context.GetcoursesData().ToListAsync();
            return View("Index", courses);
        }

        
    }
}