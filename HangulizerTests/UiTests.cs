using Hangulizer.Service;
using Hangulizer.UI;
using NUnit.Framework.Internal;
using Moq;

namespace HangulizerTests;

[TestFixture]
public class UiTests
{
    private Mock<IStdOutput> _stdOutputMock;
    private ParseInput _parseInput;
    
    [SetUp]
    public void Setup()
    {
        _stdOutputMock = new Mock<IStdOutput>();
        _parseInput = new(_stdOutputMock.Object);
    }

    [Test]
    public void CheckTestResult_PassingExit()
    {
        _stdOutputMock.Setup(x => x.Exit());
        _parseInput.Check("exit");
        _stdOutputMock.Verify(x => x.Exit(), Times.Once);
    }

    [Test]
    public void CheckTestResult_PassingClr()
    {
        _stdOutputMock.Setup(x => x.ClearScreen());
        _parseInput.Check("clr");
        _stdOutputMock.Verify(x => x.ClearScreen(), Times.Once);
    }
    
    [Test]
    public void CheckTestResult_PassingInvalidInput()
    {
        _stdOutputMock.Setup(x => x.InvalidInput());
        _parseInput.Check("");
        _stdOutputMock.Verify(x => x.InvalidInput(), Times.Once);
    }
    
    [Test]
    public void CheckTestResult_PassingHelp()
    {
        _stdOutputMock.Setup(x => x.PrintHelp());
        _parseInput.Check("help");
        _stdOutputMock.Verify(x => x.PrintHelp(), Times.Once);
    }
}