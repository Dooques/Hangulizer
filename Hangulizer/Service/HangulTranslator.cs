using System.Text;
using Hangulizer.Data;

namespace Hangulizer.Service;

public class HangulTranslator(Dictionary<string, string> hangulLibrary)
{
    private readonly int[] _jongseongMap =
    {
        0x3131, 0x3132, 0x3133, 0x3134, 0x3135, 0x3136, 0x3137, 0x3139,
        0x313A, 0x313B, 0x313C, 0x313D, 0x313E, 0x313F, 0x3140, 0x3141,
        0x3142, 0x3144, 0x3145, 0x3146, 0x3147, 0x3148, 0x314A, 0x314B,
        0x314C, 0x314D, 0x314E
    };

    public string TranslateToPhonetic(string hangulScript)
    {
        HangulTransformer ht = new();
        var splitScript = hangulScript.Split(' ');
        StringBuilder sb = new();
        
        var i = 0;
        foreach (var word in splitScript)
        {
            foreach (var t in word)
            {
                Console.WriteLine(t);
                
                var splitGuelja = ht.DecomposeCharacter(t.ToString());
                var j = 0;
                
                foreach (var jamo in splitGuelja)
                {
                    Console.WriteLine(jamo + " " + j);
                    if (jamo is 'ㅇ' && j == 0)
                    {
                        Console.WriteLine("Skipped null consonant");
                    }
                    else
                    {
                        var jamoString = jamo.ToString();
                        jamoString = hangulLibrary[jamoString];
                        sb.Append(jamoString);
                    }

                    j++;
                }
            }

            if (i < (splitScript.Length - 1))sb.Append(' ');
            i++;
        }
        return sb.ToString();
    }
}