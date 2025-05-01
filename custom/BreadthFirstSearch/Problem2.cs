// 🔹 Problem 2: Word Ladder (Leetcode-style) (Easy–Medium)
// Description:
// Given a start word, an end word, and a dictionary of words, transform the start word into the end word by changing only
// one letter at a time — each intermediate word must be in the dictionary. Return the minimum number of transformations required.

// Example:
// "hit" → "hot" → "dot" → "dog" → "cog"

// Why BFS?
// Each word is a node; you want the shortest transformation sequence. This is classic BFS on a word graph.

class Problem2
{
    public static void Execute()
    {
        string beginWord = "hit";
        string endWord = "cog";
        List<string> wordList = ["hot", "dot", "dog", "lot", "log", "cog"];


        // Expected output: 5
    }
}