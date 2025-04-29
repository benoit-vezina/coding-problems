// Write a function that takes an integer as input, and returns the number of bits that are equal to one in the
// binary representation of that number. You can guarantee that input is non-negative.

// Example: The binary representation of 1234 is 10011010010, so the function should return 5 in this case
using System.Numerics;

Console.WriteLine(Solution(1234));
Console.WriteLine(SolutionHandwritten(1234));

int Solution(int input)
{
    return BitOperations.PopCount((uint)input);
}

int SolutionHandwritten(int input)
{
    int count = 0;
    while (input > 0) {
        input &= input - 1;
        count++;
    }

    return count;
}