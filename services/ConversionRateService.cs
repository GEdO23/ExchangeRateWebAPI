using System.Text.Json;
using models.configuration;
using models.services;

namespace service;

public class ConversionRateService(HttpClient httpClient)
{
    private readonly ConfigModel _configModel = ConfigModel.Instance;

    public async Task<ConversionRate> GetConversionRateAsync()
    {
        var url = GetUrl();

        var httpResponse = await httpClient.GetAsync(url);
        
        var exchangeRateResponse =
            await GetParsedJsonAsync(httpResponse);

        var conversionRate = GetConversionRate(exchangeRateResponse!);
        
        return conversionRate;
    }

    private string GetUrl()
    {
        return string.Concat(
            _configModel.ExchangeRateApiUrl,
            _configModel.ExchangeRateApiKey,
            "/latest/USD"
        );
    }

    private async Task<ExchangeRateResponse?> GetParsedJsonAsync(HttpResponseMessage httpResponse)
    {
        var json = await httpResponse.Content.ReadAsStringAsync();

        var conversionRate =
            JsonSerializer.Deserialize<ExchangeRateResponse>(json);

        return conversionRate;
    }
    
    private ConversionRate GetConversionRate(ExchangeRateResponse exchangeRateResponse)
    {
        var conversionRate = new ConversionRate();
        
        if (exchangeRateResponse.ConversionRates.TryGetValue("BRL", out var rate)) 
            conversionRate.currency = rate;

        conversionRate.timeStamp = DateTime.Now;

        return conversionRate;
    }
}