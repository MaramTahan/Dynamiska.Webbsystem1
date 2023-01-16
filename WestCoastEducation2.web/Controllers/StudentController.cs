using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WestCoastEducation2.web.Data;
using WestCoastEducation2.web.Models;

namespace WestCoastEducation2.web.Controllers;

    [Route("[Student/admin]")]
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

        [HttpGet("create")]
    public IActionResult Create()
    {
        var student = new Student();
        return View("Create", student);

    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(Student student)
    {
        try
        {
            var exists = await _context.studentData.SingleOrDefaultAsync(
            c => c.emailAddress.Trim().ToLower() == student.emailAddress.Trim().ToLower());

            if (exists is not null)
            {
                var error = new ErrorModel
                {
                    ErrorTitle = "Ett fel har inträffat när bilen skulle sparas!"
                };

                return View("_Error", error);
            }

            await _context.studentData.AddAsync(student);
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
            var student = await _context.studentData.SingleOrDefaultAsync();

            if (student is not null) return View("Edit", student);

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
    public async Task<IActionResult> Edit(int userId, Student student)
    {
        try
        {
            var studentToUpdate = await _context.studentData.SingleOrDefaultAsync();

            if (studentToUpdate is null) return RedirectToAction(nameof(Index));

            studentToUpdate.firstName = student.firstName;
            studentToUpdate.lastName = student.lastName;
            studentToUpdate.emailAddress = student.emailAddress;
            studentToUpdate.phoneNumber = student.phoneNumber;
            studentToUpdate.address = student.address;

            _context.studentData.Update(studentToUpdate);
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
            var studentToDelete = await _context.studentData.SingleOrDefaultAsync();

            if (studentToDelete is null) return RedirectToAction(nameof(Index));

            _context.studentData.Remove(studentToDelete);
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
