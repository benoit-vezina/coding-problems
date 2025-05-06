// 🔹 Problem 1: Find the Shortest Path in an Unweighted Grid (Easy)
// Description:
// You are given a 2D grid where 0 represents open cells and 1 represents walls. Start at the top-left cell (0, 0)
// and find the shortest path to the bottom-right cell using 4-directional movement.

// Why BFS?
// BFS guarantees the shortest path in an unweighted space (each move costs the same).

public class Problem1
{
    public static int BFS(int[,] grid)
    {
        int maxX = grid.GetLength(0) - 1, maxY = grid.GetLength(1) - 1;
        if (maxX == 0 && maxY == 0) return 0;
        if (maxX == -1 && maxY == -1) return -1;

        (int x, int y) source = (0, 0);
        (int x, int y) end = (maxX, maxY);

        HashSet<(int x, int y)> visited = new([source]);
        Queue<(int x, int y)> queue = new([source]);
        int layerExploredCount = 0;
        int layerVertexCount = 1;

        while (queue.Count > 0)
        {
            (int currentX, int currentY) = queue.Dequeue();
            // Neighbooring points in the grid are calculated by incrementing or decrementing one of the indices
            foreach ((int x, int y) neighboor in GetNeighboors(currentX, currentY))
            {
                // Conditions are: Is not visited, is within the grid range and value is 0
                if (IsNeighboorValid(neighboor, visited, maxX, maxY, grid))
                {
                    if (neighboor == end) return layerExploredCount + 1;
                    visited.Add(neighboor);
                    queue.Enqueue(neighboor);
                }
            }
            if (--layerVertexCount == 0)
            {
                layerExploredCount++;
                layerVertexCount = queue.Count;
            }
        }

        return -1;
    }

    private static (int x, int y)[] GetNeighboors(int currentX, int currentY)
    {
        (int x, int y) up = (currentX - 1, currentY);
        (int x, int y) right = (currentX, currentY + 1);
        (int x, int y) down = (currentX + 1, currentY);
        (int x, int y) left = (currentX, currentY - 1);

        return [up, right, down, left];
    }

    private static bool IsNeighboorValid(
        (int x, int y) neighboor,
        HashSet<(int x, int y)> visited,
        int maxX,
        int maxY,
        int[,] grid
    ) => !visited.Contains(neighboor)
        && neighboor.x >= 0 && neighboor.x <= maxX
        && neighboor.y >= 0 && neighboor.y <= maxY
        && grid[neighboor.x, neighboor.y] == 0;

    [Theory]
    [InlineData(new int[] { 0, 0, 0, 1, 1, 0, 0, 0, 0 }, 3, 4)] // 3x3 grid with wall
    [InlineData(new int[] { 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0 }, 4, 6)] // 4x4 grid
    [InlineData(new int[] { 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0 }, 4, 6)] // Another 4x4 grid
    [InlineData(new int[] { 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0 }, 4, 6)] // Another 4x4 grid
    [InlineData(new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 }, 4, -1)] // No path available
    public void BFS_ReturnsExpectedShortestPath(int[] flatGrid, int size, int expected)
    {
        // Arrange
        int[,] grid = new int[size, size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                grid[i, j] = flatGrid[i * size + j];
            }
        }

        // Act
        int result = BFS(grid);

        // Assert
        Assert.Equal(expected, result);
    }

    // Additional test for larger grid
    [Fact]
    public void BFS_LargeGrid_ReturnsExpectedPath()
    {
        // Arrange
        int[,] grid = new int[20, 20];
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                grid[i, j] = 0;
            }
        }
        grid[10, 10] = 1; // Add a single wall

        // Act
        int result = BFS(grid);

        // Assert
        Assert.Equal(38, result);
    }
}