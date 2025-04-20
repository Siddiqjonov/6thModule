namespace Payment;

internal class PaymentFactory
{
    public static IPayment GetObject(string strategyType)
    {
        if (strategyType.ToLower() == "payme") return new PayMe();
        if (strategyType.ToLower() == "uzum") return new Uzum();
        if (strategyType.ToLower() == "click") return new Click();
        throw new Exception($"Such type : {strategyType} not exists");
    }
}
