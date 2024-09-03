using interfaces;

namespace models.services;

/// <summary>
///     Model that contains the conversion rate of different price's.
/// </summary>
public class ConversionRate : IConversionRate
{
    public decimal currency { get; set; }
    public DateTime timeStamp { get; set; }
}