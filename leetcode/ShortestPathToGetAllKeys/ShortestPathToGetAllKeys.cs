public class ShortestPathToGetAllKeys
{
    public static int ShortestPathAllKeys(string[] grid)
    {
        // First pass to find starting position and keycount
        (int x, int y, string keys) source = new(-1, -1, string.Empty);
        int keyCount = 0;
        for (int i = 0; i < grid.Length; i++)
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (IsKey(grid[i][j])) keyCount++;
                if (IsStart(grid[i][j])) source = new(i, j, string.Empty);
            }
        if (keyCount == 0) return -1;

        // Second pass to actually do the search. Note the 'visited' set with they keys, this allows use to revisit
        // previous points when we get new keys
        Queue<(int x, int y, string keys)> queue = new([source]);
        HashSet<(int x, int y, string keys)> visited = new([source]);
        int depth = 0;
        int verticesInLayer = 1;
        while (queue.Count > 0)
        {
            (int x, int y, string keys) current = queue.Dequeue();
            foreach((int x, int y, string keys) in GetNeighbors(current))
            {
                (int x, int y, string keys) neighbor = (x, y, keys);
                if (IsNeighborValid(neighbor, visited, grid))
                {
                    if (IsKey(grid[neighbor.x][neighbor.y]) && !neighbor.keys.Contains(grid[neighbor.x][neighbor.y]))
                        neighbor.keys += grid[neighbor.x][neighbor.y];
                    if (neighbor.keys.Length == keyCount) return depth + 1;
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
            if (--verticesInLayer == 0)
            {
                depth++;
                verticesInLayer = queue.Count;
            }
        }

        return -1;
    }

    // Not visited with the current keys, in bounds and not a lock that we dont have the key for
    private static (int x, int y, string keys)[] GetNeighbors((int x, int y, string keys) current)
    {
        (int x, int y, string keys) up = (current.x - 1, current.y, current.keys);
        (int x, int y, string keys) right = (current.x, current.y + 1, current.keys);
        (int x, int y, string keys) down = (current.x + 1, current.y, current.keys);
        (int x, int y, string keys) left = (current.x, current.y - 1, current.keys);

        return [up, right, down, left];
    }

    private static bool IsNeighborValid(
        (int x, int y, string keys) neighbor,
        HashSet<(int x, int y, string keys)> visited,
        string[] grid)
    {
      return !visited.Contains(neighbor)
        && neighbor.x >= 0 && neighbor.x < grid.Length
        && neighbor.y >= 0 && neighbor.y < grid[0].Length
        && (grid[neighbor.x][neighbor.y] == '.'
            || IsKey(grid[neighbor.x][neighbor.y]) || IsStart(grid[neighbor.x][neighbor.y])
            || IsLock(grid[neighbor.x][neighbor.y]) && neighbor.keys.Contains(char.ToLower(grid[neighbor.x][neighbor.y])));  
    }

    private static bool IsKey(char c) => c >= 'a' && c <= 'f';
    private static bool IsLock(char c) => c >= 'A' && c <= 'F';
    private static bool IsStart(char c) => c == '@';
}