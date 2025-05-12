namespace RemoveDuplicatesFromSortedArray;

public class RemoveDuplicatesFromSortedArrayTest
{
    [Theory]
    [InlineData(new int[]{1,1,2}, 2, new int[]{1,2,2})]
    [InlineData(new int[]{0,0,1,1,1,2,2,3,3,4}, 5, new int[]{0,1,2,3,4,2,2,3,3,4})]
    public void RemoveDuplicates_ReturnsExpectedResults(int[] nums, int expectedK, int[] expectedNums)
    {
        int k = RemoveDuplicatesFromSortedArray.RemoveDuplicates(nums);
        Assert.Equal(expectedK, k);
        Assert.Equal(expectedNums, nums);
    }
}
