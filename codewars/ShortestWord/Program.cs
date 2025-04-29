// Simple, given a string of words, return the length of the shortest word(s).

// String will never be empty and you do not need to account for different data types.

Console.WriteLine(Solution("Let's   travel abroad shall we"));

static int Solution(string s)
{
    return s.Split(' ').Min(w => w.Length > 0 ? w.Length : s.Length);
}

static int SolutionHandwritten(string s)
{
    var words = s.Trim().Split(' ');
    var currentShortestLength = words[0].Length;

    for (int i = 1; i < words.Length; i++)
    {
        if (words[i].Length == 0)
            continue;
        if (words[i].Length < currentShortestLength)
            currentShortestLength = words[i].Length;
    }

    return currentShortestLength;
}