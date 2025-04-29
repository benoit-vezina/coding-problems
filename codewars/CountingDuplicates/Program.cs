// Count the number of Duplicates
// Write a function that will return the count of distinct case-insensitive alphabetic characters and numeric digits that occur more than once in the input string. 
// The input string can be assumed to contain only alphabets (both uppercase and lowercase) and numeric digits.

// Example
// "abcde" -> 0 # no characters repeats more than once
// "aabbcde" -> 2 # 'a' and 'b'
// "aabBcde" -> 2 # 'a' occurs twice and 'b' twice (`b` and `B`)
// "indivisibility" -> 1 # 'i' occurs six times
// "Indivisibilities" -> 2 # 'i' occurs seven times and 's' occurs twice
// "aA11" -> 2 # 'a' and '1'
// "ABBA" -> 2 # 'A' and 'B' each occur twice

Console.WriteLine(Solution("Indivisibilities"));

static int Solution(string str)
{
    return str.ToUpper().GroupBy(c => c).Where(g => g.Count() > 1).Count();
}

static int SolutionHandwritten(string str)
{
    var countMap = new Dictionary<char, int>();

    foreach (char c in str)
    {
        var upperChar = char.ToUpper(c);
        countMap[upperChar] = countMap.TryGetValue(upperChar, out int value) ? value + 1 : 1;
    }

    return countMap.Where(kvp => kvp.Value > 1).Count();
}