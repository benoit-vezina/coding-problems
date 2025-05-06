public static class SimpleExample
{
    public static void Execute()
    {
        var result = GetResults();
        Console.WriteLine(string.Join(", ", result));
    }

    public static int[] GetResults()
    {
        // 1. Simple implementation and example

        // The undirected graph
        int[][] adj = new int[][] { new int[] { 1, 2 }, new int[] { 0, 2, 3 }, new int[] { 0, 1, 4 }, new int[] { 1, 4 }, new int[] { 2, 3 } };

        // The source node from where the search will start
        int source = 0;

        // This HashSet will hold every visited nodes. Its length should be equal to the total number of nodes by the end of the search
        HashSet<int> visited = new HashSet<int> { source };

        // Queue to get the next nodes to explore. The search ends when it is empty, since this means that we no longer found nodes to visit
        Queue<int> queue = new Queue<int>(new[] { source });

        // The result of the search. The sequence of the array represents the traversal order
        List<int> result = new List<int> { source };

        while (queue.Count > 0)
        {
            // Process the next element in the queue and push it to our result list
            int node = queue.Dequeue();

            // Check every neighboor of the current node
            foreach (int neighboor in adj[node])
            {
                // If the neighboor was not visited yet, add it to the traversal queue, flag it visited and push it to the traversal list
                if (!visited.Contains(neighboor))
                {
                    queue.Enqueue(neighboor);
                    visited.Add(neighboor);
                    result.Add(neighboor);
                }
            }
        }

        return result.ToArray(); // Return the result instead of just printing it
    }
}