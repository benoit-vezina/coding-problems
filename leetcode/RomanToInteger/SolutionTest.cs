namespace RomanToInteger;

public class SolutionTest
{
    [Theory]
    [InlineData("III", 3)]
    [InlineData("LVIII", 58)]
    [InlineData("MCMXCIV", 1994)]
    public void RomanToInt_ReturnsExpectedOutput(string s, int expectedOutput)
    {
        Assert.Equal(expectedOutput, Solution.RomanToInt(s));
    }
}
