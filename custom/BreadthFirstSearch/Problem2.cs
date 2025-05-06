// 🔹 Problem 2: Word Ladder (Leetcode-style) (Easy–Medium)
// Description:
// Given a start word, an end word, and a dictionary of words, transform the start word into the end word by changing only
// one letter at a time — each intermediate word must be in the dictionary. Return the minimum number of transformations (words in the path) required.

// Example:
// "hit" → "hot" → "dot" → "dog" → "cog"

// Why BFS?
// Each word is a node; you want the shortest transformation sequence. This is classic BFS on a word graph.

public class Problem2
{
    public static int BFS(string beginWord, string endWord, List<string> wordList)
    {
        wordList = [beginWord, ..wordList];
        // Transform the list of words into a graph, where each words with 1 char diff are connected
        List<List<int>> graph = BuildGraph(wordList);
        HashSet<int> visited = new([0]);
        Queue<int> queue = new([0]);
        int layersExploredCount = 0;
        int layerVerticesCount = 1;

        while (queue.Count > 0)
        {
            int vertex = queue.Dequeue();
            foreach (int neighbor in graph[vertex])
            {
                if (!visited.Contains(neighbor))
                {
                    if (wordList[neighbor] == endWord) return layersExploredCount + 2;
                    queue.Enqueue(neighbor);
                    visited.Add(neighbor);
                }
            }
            if (--layerVerticesCount == 0)
            {
                layersExploredCount++;
                layerVerticesCount = queue.Count;
            }
        }
        return -1;
    }

    private static List<List<int>> BuildGraph(List<string> wordList)
    {
        List<List<int>> graph = [];
        for (int i = 0; i < wordList.Count; i++) graph.Add([]);
        for (int i = 0; i < wordList.Count; i++)
        {
            for (int j = i + 1; j < wordList.Count; j++)
            {
                int differentCharacterCount = 0;
                for (int k = 0; k < wordList[i].Length; k++)
                    if (wordList[i][k] != wordList[j][k]) differentCharacterCount++;
                if (differentCharacterCount == 1) 
                {
                    graph[i].Add(j);
                    graph[j].Add(i);
                }
            }
        }
        return graph;
    }

    [Theory]
    [InlineData("hit", "cog", new string[] { "hot", "dot", "dog", "lot", "log", "cog" }, 5)]
    [InlineData("cat", "dog", new string[] { "bat", "cot", "cog", "dot", "dog" }, 4)]
    [InlineData("lead", "gold", new string[] { "load", "goad", "gold", "lode" }, 4)]
    [InlineData("abc", "xyz", new string[] { "abd", "xbc", "ayz" }, -1)]
    [InlineData("a", "c", new string[] { "b", "c" }, 2)]
    public void BFS_ReturnsExpectedTransformations(string beginWord, string endWord, string[] wordArray, int expected)
    {
        // Arrange
        List<string> wordList = new List<string>(wordArray);

        // Act
        int result = BFS(beginWord, endWord, wordList);

        // Assert
        Assert.Equal(expected, result);
    }
}