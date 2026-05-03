using Hangulizer.Data;
using Hangulizer.Service;

namespace Hangulizer
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            const string singleChar = "ㅏ";
            const string singleSyl = "곰";
            const string multiSyl = "다무";
            const string multiword = "안녕 친구";
            var translator = new HangulTranslator(HangulLibrary.Hangul);

            Console.WriteLine("One Character");
            Console.WriteLine(singleChar);
            translator.TranslateToPhonetic(singleChar);
            
            Console.WriteLine("\nOne Syllable");
            Console.WriteLine(singleSyl);
            translator.TranslateToPhonetic(singleSyl);
            
            Console.WriteLine("\nTwo Syllables");
            Console.WriteLine(multiSyl);
            translator.TranslateToPhonetic(multiSyl);
            
            Console.WriteLine("\nTwo Words");
            Console.WriteLine(multiword);
            translator.TranslateToPhonetic(multiword);
        }
    }
}