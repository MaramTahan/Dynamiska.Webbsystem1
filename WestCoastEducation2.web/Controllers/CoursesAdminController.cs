
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WestCoastEducation2.web.Data;
using WestCoastEducation2.web.Models;

namespace WestCoastEducation2.web.Controllers
{
    [Route("[courses/admin]")]
    public class CoursesAdminController : Controller
    {
  private readonly westcoasteducationContext _context;
        public CoursesAdminController(westcoasteducationContext context){
            _context = context;
        }
        public async Task <IActionResult> Index()
        {
            try
            {
                var courses = await _context.coursesData.ToListAsync();
                return View("Index", courses);
            }
            catch (Exception ex)
            {
                var error = new ErrorModel
            {
                ErrorTitle = "Ett fel har inträffat när vi skulle hämta alla bilar",
                ErrorMessage = ex.Message
            };

            return View("_Error", error);
                
            }
        }

        [HttpGet("create")]
    public IActionResult Create()
    {
        var course = new Courses();
        return View("Create", course);

    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(Courses course)
    {
        try
        {
            var exists = await _context.coursesData.SingleOrDefaultAsync(
            c => c.courseNumber.Trim().ToLower() == course.courseNumber.Trim().ToLower());

            if (exists is not null)
            {
                var error = new ErrorModel
                {
                    ErrorTitle = "Ett fel har inträffat när bilen skulle sparas!"
                };

                return View("_Error", error);
            }

            await _context.coursesData.AddAsync(course);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            var error = new ErrorModel
            {
                ErrorTitle = "Ett fel har inträffat när vi skulle spara bilen",
                ErrorMessage = ex.Message
            };

            return View("_Error", error);
        }
    }
    //--------------------------------------------------------------
    [HttpGet("edit/{Id}")]
    public async Task<IActionResult> Edit(int Id)
    {
        try
        {
            var course = await _context.coursesData.SingleOrDefaultAsync();

            if (course is not null) return View("Edit", course);

            var error = new ErrorModel
            {
                ErrorTitle = "Ett fel har inträffat när vi skulle hämta en bil för redigering"
            };

            return View("_Error", error);
        }
        catch (Exception ex)
        {
            var error = new ErrorModel
            {
                ErrorTitle = "Ett fel har inträffat när vi hämta bil för redigering",
                ErrorMessage = ex.Message
            };

            return View("_Error", error);
        }
    }

    [HttpPost("edit/{Id}")]
    public async Task<IActionResult> Edit(int Id, Courses course)
    {
        try
        {
            var courseToUpdate = await _context.coursesData.SingleOrDefaultAsync();

            if (courseToUpdate is null) return RedirectToAction(nameof(Index));

            courseToUpdate.courseNumber = course.courseNumber;
            courseToUpdate.name = course.name;
            courseToUpdate.startDate = course.startDate;
            courseToUpdate.endDate = course.endDate;
            courseToUpdate.teacher = course.teacher;
            courseToUpdate.placeStudy = course.placeStudy;

            _context.coursesData.Update(courseToUpdate);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            var error = new ErrorModel
            {
                ErrorTitle = "Ett fel har inträffat när vi skulle spara bilen",
                ErrorMessage = ex.Message
            };

            return View("_Error", error);
        }
    }
    //--------------------------------------------------------------
    //--------------------------------------------------------------
    [Route("delete/{Id}")]
    public async Task<IActionResult> Delete(int Id)
    {
        try
        {
            var courseToDelete = await _context.coursesData.SingleOrDefaultAsync();

            if (courseToDelete is null) return RedirectToAction(nameof(Index));

            _context.coursesData.Remove(courseToDelete);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            var error = new ErrorModel
            {
                ErrorTitle = "Ett fel har inträffat när bilen skulle raderas",
                ErrorMessage = ex.Message
            };

            return View("_Error", error);
        }
    }


    }
}