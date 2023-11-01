public class SolutionFindPeakElement {
    public int FindPeakElement(int[] nums) {
        if (nums == null || nums.Length == 0)
            return -1;
        
        int start = 0;
        int end = nums.Length - 1;

        while (start + 1 < end) {
            int mid = start + (end - start) / 2;

            if (nums[mid] >= nums[mid - 1] && nums[mid] >= nums[mid + 1])
                return mid;

            if (nums[mid] > nums[mid - 1])
                start = mid;
            else
                end = mid;
        }

        if (nums[start] < nums[end])
            return end;
        else
            return start;
    }
}