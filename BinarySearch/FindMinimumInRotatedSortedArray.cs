public class SolutionFindMin {
    public int FindMin(int[] nums) {
        if (nums == null || nums.Length == 0)
            return -1;
        
        int start = 0;
        int end = nums.Length - 1;

        while (start + 1 < end)
        {
            int mid = start + (end - start) / 2;

            if (nums[mid] > nums[start])
            {
                if (nums[mid] < nums[end])
                    end = mid;
                else
                    start = mid;
            }
            else 
            {
                end = mid;
            }
        }

        return Math.Min(nums[start], nums[end]);
    }
}