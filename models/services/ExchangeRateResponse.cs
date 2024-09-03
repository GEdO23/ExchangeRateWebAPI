using System.Text.Json.Serialization;

namespace models.services;

/// <summary>
///     The exchange rate response model for the api json response
/// </summary>
public class ExchangeRateResponse
{
    /// <summary>
    ///     Dictionary of the conversion_rates list in the api json response.
    /// </summary>
    [JsonPropertyName("conversion_rates")]
    public Dictionary<string, decimal> ConversionRates { get; set; }
}