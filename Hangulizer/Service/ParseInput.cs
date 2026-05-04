using System.Runtime.InteropServices.ComTypes;
using Hangulizer.UI;

namespace Hangulizer.Service;

public class ParseInput(IStdOutput stdOutput)
{
    public void Check(string userInput)
    {
        switch (userInput)
        {
            case "":
                stdOutput.InvalidInput();
                break;
            case "clr":
                stdOutput.ClearScreen();
                break;
            case "exit":
                stdOutput.Exit();
                break;
            case "help":
                stdOutput.PrintHelp();
                break;
        }
    }
}