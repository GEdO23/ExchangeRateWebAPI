using Microsoft.AspNetCore.Mvc;

namespace interfaces;

public interface IExchangeController
{
    /// <summary>
    ///     Getter for the exchange rate between selected price's.
    /// </summary>
    /// <returns>
    ///     The <see cref="JsonResult" /> exchange rate in <see cref="Task" /> format.
    /// </returns>
    Task<JsonResult> GetExchangeRateAsync();
}