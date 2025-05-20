namespace LongestPalindromicSubstring;

static class Solution
{
    public static string LongestPalindrome(string s)
    {
        if (s.Length == 1) return s;

        for (int currentLength = s.Length; currentLength > 1; currentLength--)
            for (int start = 0, end = currentLength - 1; end < s.Length; start++, end++)
                for (int i = start, j = end; i <= end; i++, j--)
                {
                    if (i >= j) return s[start..(end + 1)];
                    if (s[i] != s[j]) break;
                }

        return s[0..1];
    }

    public static string LongestPalindromeAiOne(string s)
    {
        if (string.IsNullOrEmpty(s) || s.Length == 1) return s;

        int start = 0, maxLength = 1;

        for (int i = 0; i < s.Length; i++)
        {
            // Expand around center for odd-length palindromes
            ExpandAroundCenter(s, i, i, ref start, ref maxLength);

            // Expand around center for even-length palindromes
            ExpandAroundCenter(s, i, i + 1, ref start, ref maxLength);
        }

        return s.Substring(start, maxLength);
    }

    private static void ExpandAroundCenter(string s, int left, int right, ref int start, ref int maxLength)
    {
        // Expand as long as we have matching characters
        while (left >= 0 && right < s.Length && s[left] == s[right])
        {
            left--;
            right++;
        }

        // Calculate palindrome length (we went one step too far)
        int length = right - left - 1;

        // Update result if longer palindrome found
        if (length > maxLength)
        {
            maxLength = length;
            start = left + 1; // Adjust start position
        }
    }
    
    public static string LongestPalindromeAiTwo(string s)
    {
        if (string.IsNullOrEmpty(s) || s.Length == 1) return s;
        
        // Transform string to handle both odd and even length palindromes
        // Insert special character between each character and at boundaries
        char[] t = new char[s.Length * 2 + 1];
        t[0] = '#';
        for (int i = 0; i < s.Length; i++)
        {
            t[2*i + 1] = s[i];
            t[2*i + 2] = '#';
        }
        
        // Array to store palindrome lengths
        int[] p = new int[t.Length];
        int center = 0, right = 0;
        int maxLen = 0, maxCenter = 0;
        
        for (int i = 0; i < t.Length; i++)
        {
            // Mirror of i with respect to center
            int mirror = 2 * center - i;
            
            // If within right boundary, use the mirror value
            if (i < right)
                p[i] = Math.Min(right - i, p[mirror]);
            
            // Expand around center i
            int a = i + (1 + p[i]);
            int b = i - (1 + p[i]);
            while (b >= 0 && a < t.Length && t[a] == t[b])
            {
                p[i]++;
                a++;
                b--;
            }
            
            // Update center and right boundary if needed
            if (i + p[i] > right)
            {
                center = i;
                right = i + p[i];
            }
            
            // Update maximum palindrome found so far
            if (p[i] > maxLen)
            {
                maxLen = p[i];
                maxCenter = i;
            }
        }
        
        // Extract the palindrome from the original string
        int start = (maxCenter - maxLen) / 2;
        return s.Substring(start, maxLen);
    }
}
