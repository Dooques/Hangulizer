using Hangulizer.Data;
using Hangulizer.Service;

namespace Hangulizer
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var translator = new HangulTransformer(HangulLibrary.Hangul);
            const string sampleHangul = "곰";
            const string expected = "ㄱㅗㅁ";

            var separateHangul = translator.DecomposeCharacter(sampleHangul);

            Console.WriteLine();
            Console.WriteLine("Separated Hangul");
            Console.WriteLine(separateHangul);
            Console.WriteLine("Expected Hangul:");
            Console.WriteLine(expected);

            var conjoinedHangul = translator.ComposeCharacters(expected);

            Console.WriteLine();
            Console.WriteLine("Separated Hangul");
            Console.WriteLine(sampleHangul);
            Console.WriteLine("Joined Hangul:");
            Console.WriteLine(conjoinedHangul);
        }
    }
}