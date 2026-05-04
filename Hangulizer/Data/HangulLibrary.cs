namespace Hangulizer.Data
{
    public static class HangulLibrary
    {
        public static Dictionary<string, string> Hangul =  new Dictionary<string, string>
        {
            // Consonants
            {"ㄱ", "g"}, {"ㅋ", "k"}, {"ㄲ", "kk"},
            {"ㄴ", "n"}, {"ㄷ", "d"}, {"ㅌ", "t"}, {"ㄸ", "tt"},
            {"ㅅ", "s"}, {"ㅈ", "j"}, {"ㅊ", "ch"}, {"ㅆ", "ss"}, {"ㅉ", "jj"},
            {"ㅁ", "m"}, {"ㅂ", "b"}, {"ㅍ", "p"}, {"ㅃ", "pp"},
            {"ㅎ", "h"}, {"ㅇ", "ng"}, {"ㄹ", "r/l"},
            // Vowels
            {"ㅡ", "eu"}, {"ㅣ", "i"},
            {"ㅓ", "eo"}, {"ㅕ", "yeo"}, 
            {"ㅏ", "a"}, {"ㅑ", "ya"},
            {"ㅗ", "o"}, {"ㅛ", "yo"},
            {"ㅜ", "u"}, {"ㅠ", "yu"},
            // Compound Vowels
            {"ㅐ", "ae"}, {"ㅒ", "yae"}, {"ㅔ", "e"}, {"ㅖ", "ye"},
            {"ㅘ", ""}, {"ㅙ", "wae"}, {"ㅚ", "oe"},
            {"ㅝ", "wo"}, {"ㅞ", "we"}, {"", ""}, 
        };
    }
}