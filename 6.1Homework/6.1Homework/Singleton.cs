using System.Diagnostics.Metrics;

namespace _6._1Homework;

public class Singleton
{
    private static Singleton instance;

    private Singleton()
    {

    }

    private static object _lock = new object();

    public static int Counter = 0;
    public static Singleton GetInstance()
    {
        if (instance == null)
        {
            instance = new Singleton();
            Console.WriteLine("new obj");
            Counter++;
        }

        return instance;
    }
}
