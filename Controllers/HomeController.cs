using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurvey.Models;

namespace DojoSurvey.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    static Survey MySurvey {get;set;}

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("/")]
    public IActionResult Form()
    {
        return View("Form");
    }

    [HttpPost("/survey/create")]
    public IActionResult SurveyCreate(Survey newSurvey)
    {
        if (!ModelState.IsValid)
        {  
            return View("Form");

        }
        System.Console.WriteLine(newSurvey.Name);
        System.Console.WriteLine(newSurvey.Location);
        System.Console.WriteLine(newSurvey.Language);
        System.Console.WriteLine(newSurvey.Comment);
            // database things
        MySurvey = newSurvey;

        return RedirectToAction("SurveyConfirmation");
    }

    [HttpGet("/survey/confirmation")]
    public IActionResult SurveyConfirmation()
    {
        System.Console.WriteLine(MySurvey.Name);
        System.Console.WriteLine(MySurvey.Location);
        System.Console.WriteLine(MySurvey.Language);
        System.Console.WriteLine(MySurvey.Comment);
        return View("Show", MySurvey);
    }


    [HttpGet("/privacy")]
    public IActionResult Show()
    {
        return View("Show");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
