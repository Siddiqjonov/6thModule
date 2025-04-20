using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyAndFactoryPatter;

public class Click : IPayment
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Payment: {amount} $ paid by Click pay");
    }
}
