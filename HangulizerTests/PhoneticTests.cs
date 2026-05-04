using Hangulizer.Data;
using Hangulizer.Service;
using Shouldly;

namespace HangulizerTests;

[TestFixture]
public class PhoneticTests
{
    [Test]
    public static void TransformerTest_OneJamo()
    {
        const string input = "ㅏ";
        const string expectedPhonetic = "a";

        HangulTranslator htp = new(HangulLibrary.Hangul);
        
        var result = htp.TranslateToPhonetic(input);
        result.ShouldBe(expectedPhonetic);
    }
    
    [Test]
    public static void TransformerTest_OneSyllable()
    {
        const string input = "곰";
        const string expectedPhonetic = "gom";

        HangulTranslator htp = new(HangulLibrary.Hangul);
        
        var result = htp.TranslateToPhonetic(input);
        result.ShouldBe(expectedPhonetic);
    }
    
    [Test]
    public static void TransformerTest_MultiSyllable()
    {
        const string input = "다무";
        const string expectedPhonetic = "damu";

        HangulTranslator htp = new(HangulLibrary.Hangul);
        
        var result = htp.TranslateToPhonetic(input);
        result.ShouldBe(expectedPhonetic);
    }
    
    [Test]
    public static void TransformerTest_MultiWord()
    {
        const string input = "안녕 친구";
        const string expectedPhonetic = "annyeong chingu";

        HangulTranslator htp = new(HangulLibrary.Hangul);
        
        var result = htp.TranslateToPhonetic(input);
        result.ShouldBe(expectedPhonetic);
    }
    
    [Test]
    public static void TransformerTest_LongWithWithㅇ()
    {
        const string input = "안녕하세요";
        const string expectedPhonetic = "annyeonghaseyo";

        HangulTranslator htp = new(HangulLibrary.Hangul);
        
        var result = htp.TranslateToPhonetic(input);
        result.ShouldBe(expectedPhonetic);
    }
}