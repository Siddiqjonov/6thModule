namespace StrategyAndFactoryPatter;

public class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please enter app name to pay: ");
        var appName = Console.ReadLine();
        Console.Write("Enter payment amount: ");
        var paymentAmount = int.Parse(Console.ReadLine());

        var paymentStrategy = PaymentFactory.GetObject(appName);
        var execute = new PaymentStrategyExecuter(paymentStrategy);
        execute.Payment(paymentAmount);

    }
}
