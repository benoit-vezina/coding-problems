namespace NextPermutation;

public class NextPermutationTest
{
    [Theory]
    [InlineData(new int[]{1,2,3}, new int[]{1,3,2})]
    [InlineData(new int[]{3,2,1}, new int[]{1,2,3})]
    [InlineData(new int[]{1,1,5}, new int[]{1,5,1})]
    [InlineData(new int[]{2,3,1}, new int[]{3,1,2})]
    [InlineData(new int[]{5,4,7,5,3,2}, new int[]{5,5,2,3,4,7})]
    [InlineData(new int[]{4,2,0,2,3,2,0}, new int[]{4,2,0,3,0,2,2})]
    public void NextPermutation_ReturnsExpectedResults(int[] nums, int[] expectedResult)
    {
        Solution.NextPermutation(nums);
        Assert.Equal(expectedResult, nums);
    }
}
