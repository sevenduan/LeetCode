public class SolutionSearchInsert {
    //https://leetcode.com/problems/search-insert-position/
    public int SearchInsert(int[] nums, int target) {
        if (nums == null || nums.Length ==0 )
            return 0;
        
        if (target <= nums[0]) 
            return 0;        

        return BinnarySearch(nums, 0, nums.Length -1, target);
    }

    private int BinnarySearch(int[] nums, int start, int end, int target)
    {
        if (start >= end)
            return nums.Length;

        while (start + 1 < end)
        {
            int mid = start + (end - start) / 2;

            if (nums[mid] == target)
                return mid;
            else if  (nums[mid] < target)
            {
                start = mid;
            }
            else
            {
                end = mid;
            }
        }

        if (nums[start] >= target)
            return start;
        
        if (nums[end] >= target)
            return end;
        
        return end + 1;
    }
}