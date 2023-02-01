using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Estore.Models;

namespace Estore.Controllers;

public class OrderController : Controller
{
    private readonly ILogger<OrderController> _logger;

    public OrderController(ILogger<OrderController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

}