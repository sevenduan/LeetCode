public class SolutionMaxSubArray {
    public int MaxSubArray(int[] nums) {
        if (nums == null || nums.Length == 0)
            return 0;

        int n = nums.Length;
        int[] f = new int[n];

        f[0] = nums[0];

        for (int i = 1; i < n; i++) {
            f[i] = Math.Max(0, f[i - 1]) + nums[i];
        }

        int result = int.MinValue;

        for (int i = 0; i < n; i++) {
            result = Math.Max(result, f[i]);
        }

        return result;
    }
}