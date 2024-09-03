namespace models.configuration;

public class ConfigModel
{
    private static readonly Lazy<ConfigModel> _instance =
        new(() => new ConfigModel());

    public readonly string ExchangeRateApiKey;
    public readonly string ExchangeRateApiUrl;

    private ConfigModel()
    {
        ExchangeRateApiKey = "1ae725cfc50ee3b08c02726b";
        ExchangeRateApiUrl = "https://v6.exchangerate-api.com/v6/";
    }

    public static ConfigModel Instance => _instance.Value;
}