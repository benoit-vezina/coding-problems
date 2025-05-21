namespace ZigzagConversion;

public class SolutionTest
{
    [Theory]
    [InlineData("PAYPALISHIRING", 3, "PAHNAPLSIIGYIR")]
    [InlineData("PAYPALISHIRING", 4, "PINALSIGYAHRPI")]
    [InlineData("A", 1, "A")]
    [InlineData("AB", 1, "AB")]
    [InlineData("AB", 2, "AB")]
    [InlineData("AB", 5, "AB")]
    public void Convert_ReturnsExpectedOutput(string s, int numRows, string expectedOutput)
    {
        Assert.Equal(expectedOutput, Solution.Convert(s, numRows));
    }
}
