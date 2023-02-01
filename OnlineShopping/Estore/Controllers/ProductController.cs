using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Estore.Models;

using BOL;
using SAL;


namespace Estore.Controllers;

public class ProductController : Controller
{
    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger)
    {
        _logger = logger;
    }
    
    
    public IActionResult Index()
    {
        ProductHubService svc=new ProductHubService();
        List<Product> allProducts=svc.GetAllProducts();
        //this.ViewData["products"]=allProducts;
        this.ViewBag.catalog = allProducts;
        TempData["dataFromIndex"]="This is data from Index view of Products";

        return View();
    }
     
    [HttpGet]
    public IActionResult Detail(int Id)
    {
        ProductHubService svc = new ProductHubService();
        Product product = svc.GetProductById(Id);
        Console.WriteLine(product.Title + " " + product.ProductId);
        this.ViewBag.currentProduct=product;

        return View();
    }

}