using Hangulizer.Data;
using Hangulizer.Service;
using Hangulizer.UI;

namespace Hangulizer
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(HangulLibrary.Hangul.Count);
            HangulTranslator ht = new(HangulLibrary.Hangul);
            UserInput ui = new();
            IStdOutput stdOut = new StdOutput();
            ParseInput pi = new(stdOut);
            var translating = true;
            
            stdOut.PrintIntroduction();
            
            while (translating)
            {
                try
                {
                    stdOut.PromptUser();
                    var input = ui.Get();
                    pi.Check(input);
                    if (input == "exit") translating = false;
                    else if (input == "clr" || input == "")
                    {
                    }
                    else stdOut.PrintResult(ht.TranslateToPhonetic(input));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}