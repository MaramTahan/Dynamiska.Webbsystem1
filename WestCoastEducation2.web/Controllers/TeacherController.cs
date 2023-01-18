
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
            try
            {
                var teachers = await _context.teacherData.ToListAsync();
            return View("Index", teachers);
            }
            catch (Exception ex)
            {
                var error = new ErrorModel{
                    ErrorMessage = ex.Message
                };
                return View("_Error", error);
               
            }
           
        }

        [HttpGet("CreateTeacher")]
    public IActionResult Create()
    {
        var teacher = new Teacher();
        return View("Create", teacher);

    }

    [HttpPost("CreateTeacher")]
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
                    ErrorTitle = "An error has occurred when saving the user!"
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
                ErrorTitle = "An error has occurred when we were trying to save the user",
                ErrorMessage = ex.Message
            };

            return View("_Error", error);
        }
    }
    //--------------------------------------------------------------

    [HttpGet("EditTeacher/{userId}")]
    public async Task<IActionResult> Edit(int userId)
    {
        try
        {
            var teacher = await _context.teacherData.SingleOrDefaultAsync();

            if (teacher is not null) return View("Edit", teacher);

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
     [HttpPost("EditTeacher/{userId}")]
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
                ErrorTitle = "An error has occurred when saving the user!",
                ErrorMessage = ex.Message
            };

            return View("_Error", error);
        }
    }
    //--------------------------------------------------------------

    [Route("DeleteTeacher/{userId}")]
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
