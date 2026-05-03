using Hangulizer.Data;
using Hangulizer.Service;
using Shouldly;

namespace HangulizerTests;
    
[TestFixture]
public class TransformerTests
{
    [Test]
    public void TextDecompositionTest_SplitSyllableIntoParts()
    {
        var sampleHangul = "곰";
        var expected = "ㄱㅗㅁ";

        var translator = new HangulTransformer();
        var result = translator.DecomposeCharacter(sampleHangul);

        result.ShouldBe(expected);
    }

    [Test]
    public void TextDecompositionTest_JoinSyllableFromJamon()
    {
        string sampleJamon = "ㄱㅗㅁ";
        string expected = "곰";

        var translator = new HangulTransformer();
        var result = translator.ComposeCharacters(sampleJamon);

        result.ShouldBe(expected);
    }
}