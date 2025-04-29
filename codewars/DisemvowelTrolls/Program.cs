// Trolls are attacking your comment section!

// A common way to deal with this situation is to remove all of the vowels from the trolls' comments, neutralizing the threat.

// Your task is to write a function that takes a string and return a new string with all vowels removed.

// For example, the string "This website is for losers LOL!" would become "Ths wbst s fr lsrs LL!".

// Note: for this kata y isn't considered a vowel.

Console.WriteLine(Solution("This website is for losers LOL!"));
Console.WriteLine(SolutionHandwritten("This website is for losers LOL!"));

static string Solution(string str)
{
    return string.Concat(str.Where(c => !"aeiouAEIOU".Contains(c)));
}

static string SolutionHandwritten(string str)
{
    var output = string.Empty;
    var vowels = new List<char>{'a', 'e', 'i', 'o', 'u'};

    foreach (char c in str)
    {
        if (!vowels.Contains(char.ToLower(c)))
            output += c;
    }

    return output;
}