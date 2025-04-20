namespace _001_Singleton;

public class Program
{
    static void Main(string[] args)
    {
        Single single1 = Single.GetInstance();

        Single single2 = Single.GetInstance();

        Console.WriteLine(object.ReferenceEquals(single1, single2));

    }
}
