using System.Text.Json;
using models.configuration;
using models.services;

namespace service;

public class ConversionRateService(HttpClient httpClient)
{
    private readonly ConfigModel _configModel = ConfigModel.Instance;

    public async Task<ConversionRate> GetConversionRateAsync()
    {
        ConversionRate conversionRate = new()
        {
            timeStamp = DateTime.Now
        };

        var url = string.Concat(
            _configModel.ExchangeRateApiUrl,
            _configModel.ExchangeRateApiKey,
            "/latest/USD"
        );

        var httpResponse = await httpClient.GetAsync(url);
        
        var exchangeRateResponse =
            await GetJsonDeserializedAsync(httpResponse);

        if (exchangeRateResponse != null && 
            exchangeRateResponse.ConversionRates.TryGetValue("BRL", out var rate)) 
            conversionRate.currency = rate;

        return conversionRate;
    }

    public async Task<ExchangeRateResponse?> GetJsonDeserializedAsync(HttpResponseMessage httpResponse)
    {
        var json = await httpResponse.Content.ReadAsStringAsync();

        JsonSerializerOptions options = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
        };

        var conversionRate =
            JsonSerializer.Deserialize<ExchangeRateResponse>(json, options);

        return conversionRate;
    }
}