using business;
using interfaces;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

/// <summary>
///     Controller used for the exchange rate between different currency's.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ExchangeController : Controller, IExchangeController
{
    private readonly ExchangeRateBusiness _business = new();

    [HttpGet]
    public async Task<JsonResult> GetExchangeRateAsync()
    {
        var exchangeRate = await _business.GetExchangeRateAsync();

        return Json(exchangeRate);
    }
}