namespace ContainerWithMostWater;

public class ContainerWithMostWaterTest
{
    [Theory]
    [InlineData(new int[]{1,8,6,2,5,4,8,3,7}, 49)]
    [InlineData(new int[]{1,1}, 1)]
    public void MaxArea_ReturnsExpectedResult(int[] height, int expectedResult)
    {
        Assert.Equal(expectedResult, ContainerWithMostWater.MaxArea(height));
    }
}
