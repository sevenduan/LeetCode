public class SolutionQuickSort {
    public int[] SortArray(int[] nums) {        
        if (nums == null || nums.Length == 0)
            return nums;

        QuickSort(nums, 0, nums.Length - 1);
        return nums;
    }
    
    private void QuickSort(int[] nums, int start, int end)
    {
        if (start >= end)
            return;

        int left = start;
        int right = end;
        int pivot = nums[(start + end) / 2];

        while (left <= right) {

            while (nums[left] < pivot && left <= right)
            {
                left++; 
            }

            while (nums[right] > pivot && left <= right)
            {
                right--;
            }

            if (left <= right) {
                Swap(nums, left, right);
                left++;
                right--;
            }
        }

        QuickSort(nums, start, right);
        QuickSort(nums, left, end);
    }

    public static void Swap(int[] nums, int i, int j)
    {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }
}