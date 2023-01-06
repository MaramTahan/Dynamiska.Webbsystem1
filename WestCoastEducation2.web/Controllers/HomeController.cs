using Microsoft.AspNetCore.Mvc;

namespace WestCoastEducation2.web.Controllers;

public class HomeController : Controller
{
    //Action method
    //url: https://localhost:7140/home/index
    public IActionResult Index()
    {
        ViewBag.welcome = "Welcome to WestCoast Education";
        ViewBag.message = "Dear student, with us you can prepare yourself before admission to the university, take a look at the list of courses currently available, and if you have any questions, you can contact us.";
        //returns a viewresult
        return View("Index");
    }

    
}
