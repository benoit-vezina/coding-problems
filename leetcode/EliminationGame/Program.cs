// 390. Elimination Game
// Medium
// Topics
// Companies
// You have a list arr of all integers in the range [1, n] sorted in a strictly increasing order. Apply the following algorithm on arr:

// Starting from left to right, remove the first number and every other number afterward until you reach the end of the list.
// Repeat the previous step again, but this time from right to left, remove the rightmost number and every other number from the remaining numbers.
// Keep repeating the steps again, alternating left to right and right to left, until a single number remains.
// Given the integer n, return the last number that remains in arr.



// Example 1:

// Input: n = 9
// Output: 6
// Explanation:
// arr = [1, 2, 3, 4, 5, 6, 7, 8, 9]
// arr = [2, 4, 6, 8]
// arr = [2, 6]
// arr = [6]
// Example 2:

// Input: n = 1
// Output: 1


// Constraints:

// 1 <= n <= 109

Console.WriteLine(LastRemaining(100000000));

// Unfortunately does not work on Leetcode because of memory issues with 100000000
static int LastRemaining(int n)
{
    // Initialize the array
    List<int> arr = [];
    for (int i = 1; i <= n; i++)
        arr.Add(i);

    // Initialize the buffer
    List<int> buffer = [];

    // Iterate until we have one number left
    while (arr.Count > 1)
    {
        // From left to right, add every number to keep to the buffer
        for (int i = 1; i < arr.Count; i += 2)
            buffer.Add(arr[i]);

        arr = [.. buffer];
        buffer.Clear();

        if (arr.Count == 1)
            break;

        // From right to left, add every number to keep to the buffer
        for (int i = arr.Count - 2; i > -1; i -= 2)
            buffer.Add(arr[i]);

        buffer.Reverse();
        arr = [.. buffer];
        buffer.Clear();
    }

    return arr[0];
}