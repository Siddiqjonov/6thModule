namespace StrategyAndFactoryPatter;

public class PaymentFactory
{
    public static IPayment GetObject(string paymentType)
    {
        if (paymentType.ToLower() == "click") return new Click();
        if (paymentType.ToLower() == "uzum") return new Uzum();
        if (paymentType.ToLower() == "payme") return new PayMe();
        throw new Exception("Such type: " + paymentType + " not exists");
    }
}
