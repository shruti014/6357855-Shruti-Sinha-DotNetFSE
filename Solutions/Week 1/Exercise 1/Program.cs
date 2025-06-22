using System;

class Singleton
{
    // Static instance - created eagerly
    public static Singleton instance = new Singleton();

    // Private constructor to prevent external instantiation
    private Singleton()
    {
        Console.WriteLine("Singleton Created.");
    }

    public void HelloWorld()
    {
        Console.WriteLine("Hello World!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Singleton.instance.HelloWorld();
    }
}