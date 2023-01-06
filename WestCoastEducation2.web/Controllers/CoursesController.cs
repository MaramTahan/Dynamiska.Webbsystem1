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
//-------------------------------------------------
//   public IActionResult Index()
//   {
//     var course = new List<Courses>{
//        new Courses{name = "programming1",courseNumber = "144650", startDate = "", endDate = "", placeStudy = "Classroom", teacher = "Michael Gustafsson"},
 
//         new Courses{name = "programming2", courseNumber = "144750", startDate = "", endDate = "", placeStudy = "Classroom", teacher = "Michael Gustafsson"
//                },
 
//         new Courses {name = "Web development1", courseNumber = "144850",startDate = "", endDate = "", placeStudy = "Distance", teacher = "Malin Trofast"
//                },
 
//         new Courses {name = "Web development2", courseNumber = "144950",startDate = "", endDate = "", placeStudy = "Distance", teacher = "Malin Trofast"
//                }
//            };
//            return View("Index", course);
//        }
//-----------------------------------------------
  public async Task<IActionResult> Index()
        {
            var courses = await _context.GetcoursesData().ToListAsync();
            return View("Index", courses);
        }

        
    }
}