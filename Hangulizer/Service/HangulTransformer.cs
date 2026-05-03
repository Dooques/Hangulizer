using System.Text;

namespace Hangulizer.Service;

public class HangulTransformer(Dictionary<string, string> hangulLibrary)
{
    private readonly Dictionary<string, string> _hangulLibrary = hangulLibrary;

    private readonly int[] _choseongMap =
    {
        0x3131, 0x3132, 0x3134, 0x3137, 0x3138, 0x3139, 0x3141, 0x3142,
        0x3143, 0x3145, 0x3146, 0x3147, 0x3148, 0x3149, 0x314A, 0x314B,
        0x314C, 0x314D, 0x314E
    };

    // Vowels (Jungseong)
    private readonly int[] _jungseongMap =
    {
        0x314F, 0x3150, 0x3151, 0x3152, 0x3153, 0x3154, 0x3155, 0x3156,
        0x3157, 0x3158, 0x3159, 0x315A, 0x315B, 0x315C, 0x315D, 0x315E,
        0x315F, 0x3160, 0x3161, 0x3162, 0x3163
    };

    // Final Consonants (Jongseong)
    private readonly int[] _jongseongMap =
    {
        0x3131, 0x3132, 0x3133, 0x3134, 0x3135, 0x3136, 0x3137, 0x3139,
        0x313A, 0x313B, 0x313C, 0x313D, 0x313E, 0x313F, 0x3140, 0x3141,
        0x3142, 0x3144, 0x3145, 0x3146, 0x3147, 0x3148, 0x314A, 0x314B,
        0x314C, 0x314D, 0x314E
    };
    
    public string DecomposeCharacter(string syllable)
    {
        var decomposedSyllable = syllable.Normalize(NormalizationForm.FormD);
        return ToSeparate(decomposedSyllable);
    }

    public string ComposeCharacters(string jamo)
    {
        var composedSyllable = jamo.Normalize(NormalizationForm.FormC);

        Console.WriteLine(composedSyllable.Length);
        return ToConjoined(composedSyllable);
    }

    private string ToSeparate(string decomposed)
    {
        StringBuilder sb = new StringBuilder();

        // Mapping arrays: These are the hex codes from the U+3130 block
        // Initial Consonants (Choseong)
        foreach (char c in decomposed)
        {
            int code = (int)c;

            if (code >= 0x1100 && code <= 0x1112) // Initial
            {
                sb.Append((char)_choseongMap[code - 0x1100]);
            }
            else if (code >= 0x1161 && code <= 0x1175) // Vowel
            {
                sb.Append((char)_jungseongMap[code - 0x1161]);
            }
            else if (code >= 0x11A8 && code <= 0x11C2) // Final
            {
                sb.Append((char)_jongseongMap[code - 0x11A8]);
            }
            else
            {
                sb.Append(c); // Not a Hangul component, keep as is
            }
        }

        return sb.ToString();

    }

    public string ToConjoined(string input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        StringBuilder sb = new StringBuilder();
        
        // This logic assumes the input is a sequence like [Initial, Vowel, Final]
        // or [Initial, Vowel]
        for (int i = 0; i < input.Length; i++)
        {
            int cIndex = _choseongMap.IndexOf(input[i]);
            
            // 1. Find Initial
            if (cIndex != -1 && i + 1 < input.Length)
            {
                int vIndex = _jungseongMap.IndexOf(input[i + 1]);
                
                // 2. Find Vowel
                if (vIndex != -1)
                {
                    // Check if there is a Final consonant
                    int fIndex = 0;
                    if (i + 2 < input.Length)
                    {
                        fIndex = _jongseongMap.IndexOf(input[i + 2]);
                        
                        // If the next character is also a vowel, the current char 
                        // cannot be a Final (it belongs to the NEXT syllable)
                        if (i + 3 < input.Length && _jungseongMap.IndexOf(input[i + 3]) != -1)
                        {
                            fIndex = 0;
                        }
                    }

                    // 3. Convert indices to Conjoining Jamo and Normalize
                    var c = (char)(0x1100 + cIndex);
                    var v = (char)(0x1161 + vIndex);
                    var f = fIndex > 0 ? (char)(0x11A8 + fIndex) : '\0';

                    string combined = f != '\0' ? $"{c}{v}{f}" : $"{c}{v}";
                    sb.Append(combined.Normalize(NormalizationForm.FormC));

                    // Advance the loop index based on whether we used 2 or 3 characters
                    i += (fIndex > 0) ? 2 : 1;
                    continue;
                }
            }
            sb.Append(input[i]); // Keep as is if it doesn't match a syllable pattern
        }

        return sb.ToString();
    }
}