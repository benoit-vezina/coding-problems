// 1. Two Sum
// Easy
// Topics
// Companies
// Hint
// Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.

// You may assume that each input would have exactly one solution, and you may not use the same element twice.

// You can return the answer in any order.

 

// Example 1:

// Input: nums = [2,7,11,15], target = 9
// Output: [0,1]
// Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
// Example 2:

// Input: nums = [3,2,4], target = 6
// Output: [1,2]
// Example 3:

// Input: nums = [3,3], target = 6
// Output: [0,1]
 

// Constraints:

// 2 <= nums.length <= 104
// -109 <= nums[i] <= 109
// -109 <= target <= 109
// Only one valid answer exists.
 

// Follow-up: Can you come up with an algorithm that is less than O(n2) time complexity?

Console.WriteLine(string.Concat(Solution([2,7,11,15], 9)), ','); // [0,1]
Console.WriteLine(string.Concat(Solution([3,2,4], 6)), ','); // [1,2]
Console.WriteLine(string.Concat(Solution([3,3], 6)), ','); // [0,1]

static int[] Solution(int[] nums, int target)
{
    // Key is the element, value is the index
    Dictionary<int, int> map = [];

    for (int i = 0; i < nums.Length; i++)
    {
        if(map.ContainsKey(target - nums[i]))
            return [map[target - nums[i]], i];
        map[nums[i]] = i;
    }

    return [];
}

static int[] SolutionAi(int[] nums, int target)
{
    // Use dictionary to store value-to-index mapping
    Dictionary<int, int> numToIndex = new Dictionary<int, int>();
    
    // One-pass approach: check as we go
    for (int i = 0; i < nums.Length; i++)
    {
        // Calculate the complement needed to reach target
        int complement = target - nums[i];
        
        // If complement exists in dictionary, we found our pair
        if (numToIndex.ContainsKey(complement))
            return [numToIndex[complement], i];
            
        // Otherwise, add current number to dictionary if not already present
        if (!numToIndex.ContainsKey(nums[i]))
            numToIndex[nums[i]] = i;
    }
    
    // Problem guarantees a solution exists, but return empty array as fallback
    return [];
}