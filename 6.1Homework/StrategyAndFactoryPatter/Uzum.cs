namespace StrategyAndFactoryPatter;

public class Uzum : IPayment
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Payment: {amount} $ paid by Uzum pay");
    }
}
