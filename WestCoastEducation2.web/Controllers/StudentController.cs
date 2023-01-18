using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WestCoastEducation2.web.Data;
using WestCoastEducation2.web.Models;

namespace WestCoastEducation2.web.Controllers;

    [Route("[student/admin]")]
    public class StudentController : Controller
    {
  private readonly westcoasteducationContext _context;
        public StudentController(westcoasteducationContext context){
            _context = context;
        }

        public async Task <IActionResult> Index()
        {
            try
            {
                var students = await _context.studentData.ToListAsync();
            return View("Index", students);
            }
            catch (Exception ex)
            {
                var error = new ErrorModel{
                    ErrorMessage = ex.Message
                };
                return View("_Error", error);
                
            }
            
        }

        [HttpGet("CreateStudent")]
    public IActionResult Create()
    {
        var student = new Student();
        return View("Create", student);

    }

    [HttpPost("CreateStudent")]
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
                    ErrorTitle = "An error has occurred when saving the user!"
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
                ErrorTitle = "An error has occurred when saving the user!",
                ErrorMessage = ex.Message
            };

            return View("_Error", error);
        }
    }
    //--------------------------------------------------------------

    [HttpGet("EditStudent/{userId}")]
    public async Task<IActionResult> Edit(int userId)
    {
        try
        {
            var student = await _context.studentData.SingleOrDefaultAsync();

            if (student is not null) return View("Edit", student);

            var error = new ErrorModel
            {
                ErrorTitle = "An error occurred when we were about to pick up a user for editing"
            };

            return View("_Error", error);
        }
        catch (Exception ex)
        {
            var error = new ErrorModel
            {
                ErrorTitle = "An error occurred when we were about to pick up a user for editing",
                ErrorMessage = ex.Message
            };

            return View("_Error", error);
        }
    }

    [HttpPost("EditStudent/{userId}")]
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
                ErrorTitle = "An error has occurred when we were trying to save the user",
                ErrorMessage = ex.Message
            };

            return View("_Error", error);
        }
    }
    //--------------------------------------------------------------

    [Route("DeleteStudent/{userId}")]
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
                ErrorTitle = "An error has occurred when the user was to be deleted",
                ErrorMessage = ex.Message
            };

            return View("_Error", error);
        }
    }
    //--------------------------------------------------------------
    }
