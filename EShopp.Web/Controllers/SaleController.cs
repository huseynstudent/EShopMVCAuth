using EShopp.Aplication.Abstacts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EShopp.Web.Controllers;
[Authorize]
public class SaleController : Controller
{
    private readonly ISaleService _saleService;

    public SaleController(ISaleService saleService)
    {
        _saleService = saleService;
    }

    [HttpPost]
    [Authorize(Roles = "Cashier")]
    public async Task<IActionResult> Buy(int id)
    {
        await _saleService.BuyAsync(id);
        return RedirectToAction("GetAllOrders", "Order");
    }
}
