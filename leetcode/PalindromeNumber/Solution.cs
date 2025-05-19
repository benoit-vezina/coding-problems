namespace PalindromeNumber;

static class Solution
{
    public static bool IsPalindrome(int x)
    {
        if (x < 0) return false;
        Stack<int> digitStack = [];
        Queue<int> digitQueue = [];
        int temp = x;
        while (temp > 0)
        {
            int digit = temp % 10;
            digitStack.Push(digit);
            digitQueue.Enqueue(digit);
            temp /= 10;
        }
        while (digitStack.Count > 0 && digitQueue.Count > 0)
            if (digitStack.Pop() != digitQueue.Dequeue()) return false;
        return true;
    }

    public static bool IsPalindromeAiOne(int x)
    {
        // Negative numbers aren't palindromes
        if (x < 0) return false;
        // Single digit is always a palindrome
        if (x < 10) return true;
        // Numbers ending with 0 can't be palindromes unless it's 0 itself
        if (x % 10 == 0 && x != 0) return false;

        // Calculate the total number of digits
        int digits = (int)Math.Floor(Math.Log10(x) + 1);

        // Compare first and last digit, then second and second-last, etc.
        for (int i = 0; i < digits / 2; i++)
        {
            int rightDigit = (x / (int)Math.Pow(10, i)) % 10;
            int leftDigit = (x / (int)Math.Pow(10, digits - i - 1)) % 10;

            if (leftDigit != rightDigit) return false;
        }

        return true;
    }
    
    public static bool IsPalindromeAiTwo(int x)
    {
        // Negative numbers aren't palindromes
        if (x < 0) return false;
        // Numbers ending with 0 can't be palindromes unless it's 0 itself
        if (x % 10 == 0 && x != 0) return false;
        
        int reversed = 0;
        // Reverse only half of the number
        while (x > reversed)
        {
            reversed = reversed * 10 + x % 10;
            x /= 10;
        }
        
        // For even number of digits: x == reversed
        // For odd number of digits: x == reversed/10 (middle digit is in reversed)
        return x == reversed || x == reversed / 10;
    }
}