using Hangulizer.Service;

namespace Hangulizer.UI;

public class UserInput()
{
    public string Get()
    {
        return Console.ReadLine() ?? "";
    }
}