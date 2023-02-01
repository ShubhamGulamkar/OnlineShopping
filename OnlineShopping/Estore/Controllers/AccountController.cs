using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Estore.Models;

namespace Estore.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;

    public AccountController(ILogger<AccountController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(String email , String password)
    {
        if(email=="shubhamgulamkar@gmail.com" && password=="hello123")
        {
            Response.Redirect("/order/index");

        }
        return View();
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(string firstname, string lastname, string  location,string email, string password)
    {
        Console.WriteLine(firstname+" "+lastname+" "+location);
        return this.RedirectToAction("Login","Account");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
