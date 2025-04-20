using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment;

public class Click : IPayment
{
    public void Pay(double amount)
    {
        Console.WriteLine($"Payment {amount} paid by Click");
    }
}
