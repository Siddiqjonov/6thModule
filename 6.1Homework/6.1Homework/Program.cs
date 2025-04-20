namespace _6._1Homework;

public class Program
{
    static void Main(string[] args)
    {
        for (int i = 0; i < 10; i++)
        {
            var newThread = new Thread(Do);
            newThread.Start();
        }

        Console.WriteLine(Singleton.Counter);
    }

    public static void Do()
    {
        var single = Singleton.GetInstance();
    }
}
