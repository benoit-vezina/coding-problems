public class ShortestPathAllKeys
{
    [Theory]
    [InlineData(new string[] { "@.a..","###.#","b.A.B" }, 8)]
    [InlineData(new string[] { "@..aA","..B#.","....b" }, 6)]
    [InlineData(new string[] { "@Aa" }, -1)]
    [InlineData(new string[] { "@...a",".###A","b.BCc" }, 10)]
    public void ShortestPathAllKeys_ShouldReturnExpectedResult(string[] grid, int expected)
    {
        // Act
        int result = ShortestPathToGetAllKeys.ShortestPathAllKeys(grid);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ShortestPathAllKeys_WithEmptyGrid_ShouldHandleGracefully()
    {
        // Arrange
        string[] grid = new string[] { };

        // Act
        int result = ShortestPathToGetAllKeys.ShortestPathAllKeys(grid);

        // Assert
        Assert.Equal(-1, result);
    }
    
    [Fact]
    public void ShortestPathAllKeys_WithNoKeys_ShouldReturnMinus1()
    {
        // Arrange
        string[] grid = new string[] { "@..." };

        // Act
        int result = ShortestPathToGetAllKeys.ShortestPathAllKeys(grid);

        // Assert
        Assert.Equal(-1, result);
    }
}