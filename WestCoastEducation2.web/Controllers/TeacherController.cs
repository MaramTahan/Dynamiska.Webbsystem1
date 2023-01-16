
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WestCoastEducation2.web.Data;
using WestCoastEducation2.web.Models;

namespace WestCoastEducation2.web.Controllers;

    [Route("[Teacher/admin]")]
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

        [HttpGet("create")]
    public IActionResult Create()
    {
        var teacher = new Teacher();
        return View("Create", teacher);

    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(Teacher teacher)
    {
        try
        {
            var exists = await _context.teacherData.SingleOrDefaultAsync(
            c => c.emailAddress.Trim().ToLower() == teacher.emailAddress.Trim().ToLower());

            if (exists is not null)
            {
                var error = new ErrorModel
                {
                    ErrorTitle = "Ett fel har inträffat när bilen skulle sparas!"
                };

                return View("_Error", error);
            }

            await _context.teacherData.AddAsync(teacher);
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

    [HttpGet("edit/{userId}")]
    public async Task<IActionResult> Edit(int userId)
    {
        try
        {
            var teacher = await _context.teacherData.SingleOrDefaultAsync();

            if (teacher is not null) return View("Edit", teacher);

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
     [HttpPost("edit/{userId}")]
    public async Task<IActionResult> Edit(int userId, Teacher teacher)
    {
        try
        {
            var teacherToUpdate = await _context.teacherData.SingleOrDefaultAsync();

            if (teacherToUpdate is null) return RedirectToAction(nameof(Index));

            teacherToUpdate.firstName = teacher.firstName;
            teacherToUpdate.lastName = teacher.lastName;
            teacherToUpdate.emailAddress = teacher.emailAddress;
            teacherToUpdate.phoneNumber = teacher.phoneNumber;
            teacherToUpdate.address = teacher.address;

            _context.teacherData.Update(teacherToUpdate);
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

    [Route("delete/{userId}")]
    public async Task<IActionResult> Delete(int userId)
    {
        try
        {
            var teacherToDelete = await _context.teacherData.SingleOrDefaultAsync();

            if (teacherToDelete is null) return RedirectToAction(nameof(Index));

            _context.teacherData.Remove(teacherToDelete);
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
    //--------------------------------------------------------------

    }
