using System.Text;
using Hangulizer.Data;

namespace Hangulizer.Service;

public class HangulTranslator(Dictionary<string, string> hangulLibrary)
{
    private readonly Dictionary<string, string> _hangulLibrary = hangulLibrary;

    public string TranslateToPhonetic(string hangulScript)
    {
        HangulTransformer ht = new();
        var splitScript = hangulScript.Split(' ');
        StringBuilder sb = new();
        
        var i = 0;
        foreach (var guelja in splitScript)
        {
            var splitGuelja = ht.DecomposeCharacter(guelja);
            var j = 0;
            foreach (var jamo in splitGuelja)
            {
                if (jamo is 'ㅇ' && j == 0) continue;
                var jamoString = jamo.ToString();
                jamoString = _hangulLibrary[jamoString];
                sb.Append(jamoString);
                j++;
            }

            if (i < (splitScript.Length - 1))sb.Append(' ');
            i++;
        }

        Console.WriteLine(sb.ToString());
        return sb.ToString();

        return "";
    }
}