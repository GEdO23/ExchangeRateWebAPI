using models.configuration;
using models.services;
using service;

namespace business;

public class ExchangeRateBusiness
{
    private readonly ConfigModel _configModel;

    public ExchangeRateBusiness()
    {
        _configModel = ConfigModel.Instance;
    }

    public async Task<ConversionRate> GetExchangeRateAsync()
    {
        using var httpClient = new HttpClient();
        var resultService =
            await new ConversionRateService(httpClient).GetConversionRateAsync();

        return resultService ?? new ConversionRate();
    }
}