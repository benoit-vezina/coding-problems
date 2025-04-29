// Complete the solution so that it returns true if the first argument(string) passed in ends with the 2nd 
// argument (also a string).

// Examples:

// solution('abc', 'bc') // returns true
// solution('abc', 'd') // returns false

Console.WriteLine(solution("abc", "bc"));
Console.WriteLine(solution("abc", "d"));

bool solution(string str, string ending)
{
    if (ending.Length > str.Length)
        return false;

    for (int i = 0, j = str.Length - ending.Length; i < ending.Length && j < str.Length; i++, j++)
    {
        if (str[j] != ending[i])
            return false;
    }

    return true;
}

// A better solution for a production env would be "str.EndsWith(ending)"