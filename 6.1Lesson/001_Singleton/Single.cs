namespace _001_Singleton;

public class Single
{   
    private static Single instance;

    private Single() { }

    private static object _lock = new object();

    public static Single GetInstance()
    {
        lock(_lock)
        {
            if (instance == null)
            {
                instance = new Single();
            }
        }

        return instance;
    }
}
