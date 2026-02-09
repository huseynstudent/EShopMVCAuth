using EShopp.Aplication.Abstacts;
using EShopp.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
namespace EShopp.Web.Controllers;

[Authorize]
public class ProductController : Controller
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public ProductController(IProductService productService, ICategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateProduct()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();
        ViewBag.Categories = categories
            .Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            })
            .ToList();

        return View();
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateProduct(Product product)
    {
        await _productService.AddProduct(product);
        return RedirectToAction("CreateProduct", "Product");
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _productService.GetAllWithCategoryAsync();
        return View(products);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        await _productService.RemoveProduct(id);
        return RedirectToAction("GetAllProducts");
    }

    [HttpPost]
    [Authorize(Roles = "Cashier")]
    public async Task<IActionResult> AddToCart(int id)
    {
        await _productService.AddToCart(id);
        return RedirectToAction("GetAllProducts");
    }
    [HttpPost]
    [Authorize(Roles = "Admin,Cashier")]
    public async Task<IActionResult> AddStock(int id)
    {
        await _productService.AddStock(id);
        return RedirectToAction("GetAllProducts");
    }
}
