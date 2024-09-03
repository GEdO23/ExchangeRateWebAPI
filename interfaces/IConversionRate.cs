namespace interfaces;

public interface IConversionRate
{
    public decimal currency { get; set; }
    public DateTime timeStamp { get; set; }
}