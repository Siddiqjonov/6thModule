namespace Payment;

public class PayMe : IPayment
{
    public void Pay(double amount)
    {
        Console.WriteLine($"Payment {amount} paid by PayMe");
    }
}
