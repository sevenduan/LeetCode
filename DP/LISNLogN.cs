public class SolutionLengthOfLISNLogN {
    public int LengthOfLIS(int[] nums) {
        if (nums == null || nums.Length == 0) {
            return 0;
        }

        List<int> ans = new List<int>();
        ans.Add(nums[0]);        

        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] > ans[ans.Count - 1]) {
                ans.Add(nums[i]);
            } else {
                //find first larger than nums[i] in ans
                int low = BinarySearch(ans, nums[i]);
                ans[low] = nums[i];
            }
        }
        return ans.Count;
    }
    
    private int BinarySearch(IList<int> ans, int target) {
        // find first > target
        int start = 0;
        int end = ans.Count - 1;

        while (start + 1 < end) {
            int middle = (start + end) / 2;

            if (ans[middle] < target) {
                start = middle;
            } else {
                end = middle;
            }
        }

        if (ans[start] >= target)
            return start;
        else 
            return end;
    } 
}