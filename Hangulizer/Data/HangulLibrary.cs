namespace Hangulizer.Data;
    public static class HangulLibrary
    {
        public static readonly Dictionary<string, string> Hangul =  new() 
        {
            // Consonants
            {"ㄱ", "g"}, {"ㅋ", "k"}, {"ㄲ", "kk"},
            {"ㄴ", "n"}, {"ㄷ", "d"}, {"ㅌ", "t"}, {"ㄸ", "tt"},
            {"ㅅ", "s"}, {"ㅈ", "j"}, {"ㅊ", "ch"}, {"ㅆ", "ss"}, {"ㅉ", "jj"},
            {"ㅁ", "m"}, {"ㅂ", "b"}, {"ㅍ", "p"}, {"ㅃ", "pp"},
            {"ㅎ", "h"}, {"ㅇ", "ng"}, {"ㄹ", "r"}, {"xㄹ", "l"},
            // Vowels
            {"ㅡ", "eu"}, {"ㅗ", "o"}, {"ㅛ", "yo"}, {"ㅜ", "u"}, {"ㅠ", "yu"},
            {"ㅣ", "i"}, {"ㅓ", "eo"}, {"ㅕ", "yeo"}, {"ㅏ", "a"}, {"ㅑ", "ya"},
            // Compound Vowels
            {"ㅐ", "ae"}, {"ㅒ", "yae"}, {"ㅔ", "e"}, {"ㅖ", "ye"},
            {"ㅘ", "wa"}, {"ㅙ", "wae"}, {"ㅚ", "oe"}, {"ㅝ", "wo"}, {"ㅞ", "we"}, {"ㅟ", "wi"}, {"ㅢ", "ui"},
            // Compound Consonants
            {"ㄳ", "ks"}, {"ㄵ", "nj"}, {"ㄶ", "nh"}, {"ㄺ", "lg"}, {"ㄻ", "lm"},
            {"ㄼ", "lb"}, {"ㄽ", "ls"}, {"ㄾ", "lt"}, {"ㄿ", "lp"}, {"ㅀ", "lh"}, {"ㅄ", "bs"}, 
        };
    }