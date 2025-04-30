// 3. Longest Substring Without Repeating Characters
// Medium
// Topics
// Companies
// Hint
// Given a string s, find the length of the longest substring without duplicate characters.

 

// Example 1:

// Input: s = "abcabcbb"
// Output: 3
// Explanation: The answer is "abc", with the length of 3.
// Example 2:

// Input: s = "bbbbb"
// Output: 1
// Explanation: The answer is "b", with the length of 1.
// Example 3:

// Input: s = "pwwkew"
// Output: 3
// Explanation: The answer is "wke", with the length of 3.
// Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
 

// Constraints:

// 0 <= s.length <= 5 * 104
// s consists of English letters, digits, symbols and spaces.

Console.WriteLine(Solution("abcabcbb")); // 3
Console.WriteLine(Solution("bbbbb")); // 1
Console.WriteLine(Solution("pwwkew")); // 3
Console.WriteLine(Solution("aab")); // 2
Console.WriteLine(Solution("")); // 0
Console.WriteLine(Solution("cdd")); // 2
Console.WriteLine(Solution("a")); // 1
Console.WriteLine(Solution("au")); // 2
Console.WriteLine(Solution("ohomm")); // 3
Console.WriteLine(Solution("abba")); // 2

static int Solution(string s)
{
    int maxLength = 0, windowStart = 0;
    Dictionary<char, int> charPosition = [];

    for (int windowEnd = 0; windowEnd < s.Length; windowEnd++)
    {
        char currentChar = s[windowEnd];
        if (charPosition.TryGetValue(currentChar, out int index) && index >= windowStart)
        {
            windowStart = index + 1;
        }
        charPosition[currentChar] = windowEnd;
        maxLength = Math.Max(maxLength, windowEnd - windowStart + 1);
    }

    return maxLength;
}