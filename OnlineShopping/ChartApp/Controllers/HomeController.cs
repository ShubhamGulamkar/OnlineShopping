using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChartApp.Models;

namespace ChartApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        //this.myData = "seed";
        return View();
    }

    public IActionResult Privacy()
    {
        //this.myData = "KnowIT";
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
