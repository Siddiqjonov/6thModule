namespace Payment;

public class Program
{
    static void Main(string[] args)
    {
        var type = "Payme";

        var strategyType = PaymentFactory.GetObject(type);

        var notifyStrategy = new StrategyServiceExec(strategyType);
        notifyStrategy.ExecutePayment(1000);
    }
}
