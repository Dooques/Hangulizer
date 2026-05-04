namespace Hangulizer.UI;

public interface IStdOutput
{
    void PrintIntroduction();
    void PromptUser();
    public void PrintHelp();
    void PrintResult(string result);
    void ClearScreen();
    void InvalidInput();
    void Exit();   
}

public class StdOutput : IStdOutput
{
    public void PrintIntroduction()
    {
        Console.WriteLine("안뇽핫새유! Welcome to Hangulizer! ㅇuㅇ ");
        Console.WriteLine("I can convert hangul characters into their english phonetics");
        Console.WriteLine("Write your hangul script below and I'll convert it for you!");
        Console.WriteLine("If you wish to exit, type 'exit'");
        Console.WriteLine();
    }

    public void PromptUser()
    {
        Console.WriteLine("Enter your hangul script:");
        Console.Write("가다> ");
    }

    public void PrintHelp()
    {
        Console.WriteLine("Help:");
        Console.WriteLine("exit - exit the application");
        Console.WriteLine("clr - clear the screen");
    }

    public void PrintResult(string result)
    {
        Console.WriteLine(result);
        Console.WriteLine();
    }

    public void ClearScreen()
    {
        Console.Clear();
    }

    public void InvalidInput()
    {
        Console.WriteLine("Please enter a valid response");
        Console.WriteLine();
    }
    
    public void Exit()
    {
        Console.WriteLine("Goodbye!");
    }
}