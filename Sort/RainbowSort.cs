public class SolutionRainbowSort {
    public int[] SortArray(int[] nums, int target) {        
        if (nums == null || nums.Length == 0)
            return nums;

        RainbowSort(nums, 0, nums.Length - 1, 1, target);
        return nums;
    }
    
    private void RainbowSort(int[] nums, int start, int end, int colorFrom, int colorTo) {
        if (colorFrom == colorTo) {
            return;
        }
        
        if (start >= end) {
            return;
        }
        
        int left = start;
        int right = end;
        int colorMid = (colorFrom + colorTo) / 2;
        
        while (left <= right) {
            while (left <= right && nums[left] <= colorMid) {
                left++;
            }
            while (left <= right && nums[right] >= colorMid) {
                right--;
            }

            if (left <= right) {
                Swap(nums, left, right);
                left++;
                right--;
            }
        }
        RainbowSort(nums, start, right, colorFrom, colorMid);
        RainbowSort(nums, left, end, colorMid + 1, colorTo);
    }


    public static void Swap(int[] nums, int i, int j)
    {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }
}