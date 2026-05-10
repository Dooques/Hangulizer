using Hangulizer.Data;
using Hangulizer.Service;
using Shouldly;

namespace HangulizerTests;

[TestFixture]
public class PhoneticTests
{
    
    [TestCase("ㅏ", "a")]
    [TestCase("곰", "gom")]
    [TestCase("다무", "damu")]
    [TestCase("안녕 친구", "annyeong chingu")]
    [TestCase("안녕하세요", "annyeonghaseyo")]
    public static void TranslatorTests_Basic(string input, string expected)
    {
        HangulTranslator ht = new(HangulLibrary.Hangul);
        
        var result = ht.TranslateToPhonetic(input);
        result.ShouldBe(expected);
    }
    
    [TestCase("우유", "uyu")]
    [TestCase("사과", "sagwa")]
    [TestCase("의자", "uija")]
    [TestCase("위에", "wie")]
    public static void TranslatorTests_BasicVowels(string input, string expected)
    {
        HangulTranslator ht = new(HangulLibrary.Hangul);
        
        var result = ht.TranslateToPhonetic(input);
        result.ShouldBe(expected);
    }
    
    
    [TestCase("강", "gang")]
    [TestCase("아이", "ai")]
    public static void TranslatorTests_LeungPlacement(string input, string expected)
    {
        HangulTranslator ht = new(HangulLibrary.Hangul);
        
        var result = ht.TranslateToPhonetic(input);
        result.ShouldBe(expected);
    }
    
    [TestCase("빵", "ppang")]
    [TestCase("학교", "hakgyo")]
    [TestCase("앉아", "anja")]
    [TestCase("닭", "dalg")]
    public static void TranslatorTests_DoublesAndBatchim(string input, string expected)
    {
        HangulTranslator ht = new(HangulLibrary.Hangul);
        
        var result = ht.TranslateToPhonetic(input);
        result.ShouldBe(expected);
    }
    
    [TestCase("안녕!", "annyeong!")]
    [TestCase("123", "123")]
    public void TranslatorTests_NonHangulCharacters(string input, string expected)
    {
        HangulTranslator ht = new(HangulLibrary.Hangul);
        var result = ht.TranslateToPhonetic(input);
        result.ShouldBe(expected);
    }
    
    
    [TestCase("국물", "gungmul")] // Nasalization: k + m = ng + m
    [TestCase("입니다", "imnida")] // Nasalization: p + n = m + n    [TestCase("신라", "silla")] // Lateralization: n + r = l + l
    [TestCase("한류", "hallyu")] // Lateralization: n + r = l + l
    [TestCase("축하", "chuka")] // Aspiration: k + h = k (aspirated)
    [TestCase("입학", "iphak")] // Aspiration: p + h = ph
    [TestCase("먹어", "meogeo")] // Liaison: k slides to the next syllable
    [TestCase("앉아", "anja")]   // Liaison: j slides to the next syllable
    public void Translator_CollisionCharacters(string input, string expected)
    {
        var ht = new HangulTranslator(HangulLibrary.Hangul);
        var result = ht.TranslateToPhonetic(input);
        result.ShouldBe(expected);
    }
    
    [TestCase("안녕하세요, 제 이름은...","annyeonghaseyo, je ireumeun...")]
    public static void TranslatorTests_FinalTest(string input, string expected)
    {
        HangulTranslator ht = new(HangulLibrary.Hangul);
        
        var result = ht.TranslateToPhonetic(input);
        result.ShouldBe(expected);
    }
}