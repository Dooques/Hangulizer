using Hangulizer.Data;
using Hangulizer.Service;
using Shouldly;

namespace HangulizerTesting;

public class Tests
{
    [Test]
    public void TextDecompositionTest_SplitSyllableIntoParts()
    {
        string sampleHangul = "곰";
        string expected = "ㄱㅗㅁ";

        var translator = new HangulTransformer(HangulLibrary.Hangul);
        var result = translator.DecomposeCharacter(sampleHangul);
        
        result.ShouldBe(expected);
    }
    
    [Test]
    public void TextDecompositionTest_JoinSyllableFromJamon()
    {
        string sampleJamon = "ㄱㅗㅁ";
        string expected = "곰";

        var translator = new HangulTransformer(HangulLibrary.Hangul);
        var result = translator.ComposeCharacters(sampleJamon);
        
        result.ShouldBe(expected);
    }
}