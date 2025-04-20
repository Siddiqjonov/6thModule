namespace Payment;

public class StrategyServiceExec
{
    private readonly IPayment _payment;

    public StrategyServiceExec(IPayment payment)
    {
        _payment = payment;
    }

    public void ExecutePayment(double paymentAmount)
    {
        _payment.Pay(paymentAmount);
    }
}
