namespace ContainerWithMostWater;

static class ContainerWithMostWater
{
    public static int MaxArea(int[] height)
    {
        int left = 0, right = height.Length - 1 , currentHighestArea = 0;

        do
        {
            int area = Math.Min(height[left], height[right]) * (right - left);
            if (area > currentHighestArea) currentHighestArea = area;
            if (height[left] <= height[right]) left++;
            else right--;
        } while (left < right);

        return currentHighestArea;
    }
}