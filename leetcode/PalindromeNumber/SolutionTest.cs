namespace PalindromeNumber;

public class SolutionTest
{
    [Theory]
    [InlineData(121, true)]
    [InlineData(-121, false)]
    [InlineData(10, false)]
    [InlineData(int.MaxValue, false)]
    [InlineData(int.MinValue, false)]
    public void IsPalindrome_ReturnsExpectedOutput(int input, bool expectedOutput)
    {
        Assert.Equal(expectedOutput, Solution.IsPalindrome(input));
    }
}
