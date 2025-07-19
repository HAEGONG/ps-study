namespace ps_study;

public static class ExampleHelper
{
    public static void Example(string description, Action action)
    {
        Console.WriteLine($"--- Example of: {description} ---");
        action();
    }
}