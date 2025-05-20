namespace LongestPalindromicSubstring;

public class SolutionTest
{
    [Theory]
    [InlineData("babad", new string[]{"bab", "aba"})]
    [InlineData("cbbd", new string[]{"bb"})]
    [InlineData("bb", new string[]{"bb"})]
    [InlineData("ac", new string[]{"a", "c"})]
    [InlineData("aacabdkacaa", new string[]{"aca"})]
    [InlineData("aacdefcaa", new string[]{"aa"})]
    [InlineData("ccd", new string[]{"cc"})]
    public void LongestPalindrome_ReturnsPossibleOutput(string s, string[] possibleOutputs)
    {
        Assert.Contains(Solution.LongestPalindrome(s), possibleOutputs);
    }
}
