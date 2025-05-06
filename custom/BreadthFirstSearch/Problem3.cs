// 🔹 Problem 3: Minimum Number of Steps to Reach a Target Number (Medium)
// Description:
// You start at 0. At each step i, you can choose to either move forward by +i or backward by -i. What’s the minimum number
// of steps needed to reach a given number target?

// Why BFS?
// Each state (current number, step count) is a node. BFS explores all reachable numbers level-by-level to find the
// shortest sequence to reach target.

public class Problem3
{
    public static int BFS(int target)
    {
        int source = 0;
        int treeDepth = 0;
        int depthVerticesCount = 1;
        Queue<int> queue = new([source]);

        while (queue.Count > 0)
        {
            int vertex = queue.Dequeue();
            int[] children = [vertex - treeDepth - 1, vertex + treeDepth + 1];
            foreach (int child in children)
            {
                if (child == target) return treeDepth + 1;
                queue.Enqueue(child);
            }
            if (--depthVerticesCount == 0)
            {
                treeDepth++;
                depthVerticesCount = queue.Count;
            }
        }

        return -1;
    }

    // [Theory]
    // [InlineData(3, 2)]
    // [InlineData(4, 3)]
    // [InlineData(5, 3)]
    // [InlineData(7, 4)]
    // [InlineData(10, 4)]
    // [InlineData(-5, 3)]
    // [InlineData(-8, 4)]
    // [InlineData(-12, 5)]
    // [InlineData(-21, 6)]
    // [InlineData(0, 0)]
    // public void BFS_ReturnsExpectedSteps(int target, int expected)
    // {
    //     // Act
    //     int result = BFS(target);

    //     // Assert
    //     Assert.Equal(expected, result);
    // }
}