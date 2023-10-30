public class SolutionSearch {
    public int Search(int[] nums, int target) {
        if (nums == null || nums.Length == 0)
            return -1;

        int start = 0;
        int end = nums.Length - 1;

        while (start + 1 < end)
        {
            int mid = start + (end - start) / 2;

            if (nums[mid] == target)
                return mid;

            if (nums[mid] >= nums[start])
            {
                if (nums[mid] > target && target >= nums[start])
                    end = mid;
                else
                    start = mid;
            }
            else
            {
                if (nums[mid] < target && target <= nums[end])
                    start = mid;
                else
                    end = mid;
            }
        }

        if (nums[start] == target)
            return start;
        
        if (nums[end] == target)
            return end;
        
        return -1;
    }
}