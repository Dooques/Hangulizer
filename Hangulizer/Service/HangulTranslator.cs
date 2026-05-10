using System.Text;
using Hangulizer.Data;

namespace Hangulizer.Service;

public class HangulTranslator(Dictionary<string, string> hangulLibrary)
{
    public string TranslateToPhonetic(string hangulScript)
    {
        HangulTransformer ht = new();
        var splitScript = hangulScript.Split(' ');
        StringBuilder sb = new();
        
        var scriptIndex = 0;
        Console.WriteLine("Word:" + scriptIndex);
        foreach (var word in splitScript)
        {
            Console.WriteLine(word);
            var wordIndex = 0;
            foreach (var guelja in word)
            {
                var splitGuelja = ht.DecomposeCharacter(guelja.ToString());
                var gueljaIndex = 0;

                Console.WriteLine("Guelja:" + gueljaIndex);
                Console.WriteLine(guelja);
                
                var jamoString = "";
                foreach (var jamo in splitGuelja)
                {
                    Console.WriteLine("jamo: " + jamo);
                    switch (jamo)
                    {
                        case 'ㅇ' when gueljaIndex == 0:
                            break;
                        case 'ㄹ' when gueljaIndex == splitGuelja.Length - 1:
                            jamoString = "xㄹ";
                            break;
                        case 'ㄱ' when word.Length > 1 && wordIndex < word.Length - 1 && word[wordIndex + 1].ToString()[0] is 'ㅁ':
                            jamoString = "ㅇ";
                            break;
                        case 'ㄴ' when word.Length > 1 && wordIndex < word.Length -1 && word[wordIndex + 1].ToString()[0] is 'ㄹ':
                            jamoString = "xㄹ";
                            break;
                        case 'ㅂ' when word.Length > 1 && wordIndex < word.Length - 1 && word[wordIndex + 1].ToString()[0] is 'ㄴ':
                            jamoString = "ㅁ";
                            break;
                        case 'ㄹ' when wordIndex > 0 && wordIndex < word.Length -1 && ht.DecomposeCharacter(word[^1].ToString())[^1] is 'ㅇ':
                            jamoString = "ㄴ";
                            break;
                        case 'ㄱ' when gueljaIndex == splitGuelja.Length - 1:
                        case 'ㄵ' when wordIndex == word.Length - 1:
                        case 'ㄳ' when wordIndex == word.Length - 1: 
                            jamoString = "ㅋ";
                            break;
                        default:
                            jamoString = jamo.ToString();
                            break;
                    }

                    if (char.IsLetter(jamo) && jamoString is not "")
                    {
                        Console.WriteLine("Letter Found: " + jamo);
                        Console.WriteLine(jamoString = hangulLibrary[jamoString]);
                    }
                    
                    sb.Append(jamoString);
                    gueljaIndex++;
                }
                wordIndex++;
            }
            
            if (scriptIndex < (splitScript.Length - 1))sb.Append(' ');
            scriptIndex++;
        }
        return sb.ToString();
    }
}