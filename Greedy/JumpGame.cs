public class SolutionGreedy {
    public bool CanJump(int[] nums) {
        if (nums == null || nums.Length == 0)
            return false;

        int farthest = nums[0];
        for (int i = 1; i < nums.Length; i++) {
            if (i <= farthest && nums[i] + i >= farthest) {
                farthest = nums[i] + i;
            }
        }
        return farthest >= nums.Length - 1;
    }
}