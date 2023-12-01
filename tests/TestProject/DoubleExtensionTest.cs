namespace TestProject;

public class DoubleExtensionTest
{
    [Fact(DisplayName = "丸めテスト")]
    public void RoundTest()
    {
        var actual = 1.23456789.Round(3);
        
        Assert.Equal(1.235, actual);
    }
    
    [Theory(DisplayName = "パラメータ付き丸めテスト")]
    [InlineData(1.51, 1, RoundMode.Round, 1.5)]
    [InlineData(1.51, 1, RoundMode.Floor, 1.5)]
    [InlineData(1.51, 1, RoundMode.Ceiling, 1.6)]
    [InlineData(1.51, 2, RoundMode.Round, 1.51)]
    [InlineData(1.51, 2, RoundMode.Floor, 1.51)]
    [InlineData(1.51, 2, RoundMode.Ceiling, 1.51)]
    public void RoundWithParameterTest(double value, int position, RoundMode mode, double expected)
    {
        var actual = value.Round(position, mode);
        
        Assert.Equal(expected, actual);
    }
}