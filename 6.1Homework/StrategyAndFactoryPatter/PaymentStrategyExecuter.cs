namespace StrategyAndFactoryPatter;

public class PaymentStrategyExecuter
{
    private readonly IPayment payment;

    public PaymentStrategyExecuter(IPayment payment)
    {
        this.payment = payment;
    }

    public void Payment(decimal paymentAmount)
    {
        payment.Pay(paymentAmount);
    }
}
