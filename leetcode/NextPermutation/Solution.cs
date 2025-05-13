namespace NextPermutation;

static class Solution
{
    public static void NextPermutation(int[] nums)
    {
        int i = nums.Length - 2;
        while (i >= 0 && nums[i] >= nums[i + 1]) i--;
        if (i >= 0)
        {
            int j = nums.Length - 1;
            while(nums[j] <= nums[i]) j--;
            (nums[i], nums[j]) = (nums[j], nums[i]);
        }
        for (int k = i + 1, j = 1; k <= nums.Length - j; k++, j++)
            (nums[k], nums[^j]) = (nums[^j], nums[k]);
    }
}