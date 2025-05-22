namespace RomanToInteger;

static class Solution
{
    public static int RomanToInt(string s)
    {
        Numeral[] numerals = [
            new('I', 1, new Dictionary<char, int>{ { 'V', 4}, { 'X', 9 } }),
            new('V', 5, []),
            new('X', 10, new Dictionary<char, int>{ { 'L', 40}, { 'C', 90 } }),
            new('L', 50, []),
            new('C', 100, new Dictionary<char, int>{ { 'D', 400}, { 'M', 900 } }),
            new('D', 500, []),
            new('M', 1000, []),
        ];
        int value = 0;
        for (int i = 0; i < s.Length; i++)
        {
            Numeral num = numerals.First(n => n.Symbol == s[i]);
            if (i + 1 < s.Length && num.Pair.TryGetValue(s[i + 1], out int pair))
            {
                value += pair;
                i++;
            }
            else value += num.Value;
        }

        return value;
    }

    private class Numeral(char symbol, int value, Dictionary<char, int> pair)
    {
        public char Symbol { get; set; } = symbol;
        public int Value { get; set; } = value;
        public Dictionary<char, int> Pair { get; set; } = pair;
    }

    public static int RomanToIntAiOne(string s)
    {
        // Dictionary for direct value lookups
        Dictionary<char, int> values = new Dictionary<char, int>
        {
            ['I'] = 1,
            ['V'] = 5,
            ['X'] = 10,
            ['L'] = 50,
            ['C'] = 100,
            ['D'] = 500,
            ['M'] = 1000
        };

        int result = 0;
        for (int i = 0; i < s.Length; i++)
        {
            // If current value is less than next value, subtract current
            if (i + 1 < s.Length && values[s[i]] < values[s[i + 1]])
                result -= values[s[i]];
            else
                result += values[s[i]];
        }

        return result;
    }
    
    public static int RomanToIntAiTwo(string s)
    {
        Dictionary<char, int> map = new Dictionary<char, int>
        {
            ['I'] = 1,
            ['V'] = 5,
            ['X'] = 10,
            ['L'] = 50,
            ['C'] = 100,
            ['D'] = 500,
            ['M'] = 1000
        };
        
        int result = 0;
        int prev = 0;
        
        // Process from right to left
        for (int i = s.Length - 1; i >= 0; i--)
        {
            int current = map[s[i]];
            
            // If current value is greater than or equal to previous, add it
            // Otherwise subtract it (handles cases like IV, IX, etc.)
            result += (current >= prev) ? current : -current;
            
            prev = current;
        }
        
        return result;
    }
}
