// 🔹 Problem 1: Find the Shortest Path in an Unweighted Grid (Easy)
// Description:
// You are given a 2D grid where 0 represents open cells and 1 represents walls. Start at the top-left cell (0, 0)
// and find the shortest path to the bottom-right cell using 4-directional movement.

// Why BFS?
// BFS guarantees the shortest path in an unweighted space (each move costs the same).

class Problem1
{
    public static void Execute()
    {
        int[,] grid = {
            {0, 0, 0},
            {1, 1, 0},
            {0, 0, 0}
        };
        Console.WriteLine(BFS(grid)); // Expected output: 4

        int[,] grid1 = {
            {0, 1, 0, 0},
            {0, 1, 1, 0},
            {0, 0, 0, 0},
            {0, 0, 1, 0}
        };
        Console.WriteLine(BFS(grid1)); // Expected output: 6

        int[,] grid2 = {
            {0, 0, 0, 0},
            {1, 1, 0, 1},
            {0, 1, 0, 0},
            {0, 0, 0, 0}
        };
        Console.WriteLine(BFS(grid2)); // Expected output: 6

        int[,] grid3 = {
            {0, 0, 1, 0},
            {1, 0, 1, 0},
            {0, 0, 0, 0},
            {0, 1, 1, 0}
        };
        Console.WriteLine(BFS(grid3)); // Expected output: 6

        int[,] grid4 = {
            {0, 1, 1, 1},
            {1, 1, 1, 1},
            {1, 1, 1, 1},
            {1, 1, 1, 0}
        };
        Console.WriteLine(BFS(grid4)); // Expected output: -1

        int[,] grid5 = new int[20, 20];
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
            grid5[i, j] = 0; // Fill the grid with open cells
            }
        }
        grid5[10, 10] = 1; // Add a single wall for variety
        Console.WriteLine(BFS(grid5)); // Expected output: 38
    }

    private static int BFS(int[,] grid)
    {
        (int min, int max) RANGE = (min: 0, max: grid.GetLength(0) - 1);
        (int y, int x) source = (y: 0, x: 0);
        (int y, int x) end = (y: RANGE.max, x: RANGE.max);
        
        // Check if start or end is a wall
        if (grid[source.y, source.x] == 1 || grid[end.y, end.x] == 1) return -1;
        
        // Check if start is already the end
        if (source == end) return 0;
        
        Queue<(int y, int x)> queue = new([source]);
        HashSet<(int y, int x)> visited = [source]; // Mark start as visited immediately
        int steps = 0;
        
        while (queue.Count > 0)
        {
            int nodesInCurrentLevel = queue.Count;
            
            // Process all nodes at current level
            for (int i = 0; i < nodesInCurrentLevel; i++)
            {
                var point = queue.Dequeue();
                
                // Check if we've reached the end
                if (point.y == end.y && point.x == end.x)
                    return steps;
                
                (int y, int x) up = (y: point.y - 1, point.x);
                (int y, int x) right = (point.y, point.x + 1);
                (int y, int x) down = (y: point.y + 1, point.x);
                (int y, int x) left = (point.y, point.x - 1);
                (int y, int x)[] neighbors = [up, right, down, left];
                
                foreach ((int y, int x) neighbor in neighbors)
                {
                    // Check if the neighbor is valid and not visited
                    if (neighbor.y >= RANGE.min && neighbor.y <= RANGE.max
                        && neighbor.x >= RANGE.min && neighbor.x <= RANGE.max
                        && !visited.Contains(neighbor)
                        && grid[neighbor.y, neighbor.x] != 1)
                    {
                        visited.Add(neighbor); // Mark as visited when enqueueing
                        queue.Enqueue(neighbor);
                    }
                }
            }
            
            // Increment steps after processing all nodes at current level
            steps++;
        }
        
        return -1; // No path found
    }
}