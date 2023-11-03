public class SolutionLengthOfLIS {
    public int LengthOfLIS(int[] nums) {
        if (nums == null || nums.Length == 0) {
            return 0;
        }
        int[] f = new int[nums.Length];
        //f[i]= jump in any position = 1;
        //function
        // f[i] = max(f[j] + 1, f[i]) j<i && nums[j] < nums[i]

        for (int i = 0; i < nums.Length; i++) {
            f[i] = 1;
            for (int j = 0; j < i; j++) {
                if(nums[j] < nums[i]) {
                    f[i] = Math.Max(f[i], f[j] + 1);
                }
            }
        }

        int best = 0;
        for (int i = 0; i < nums.Length; i++) {
            best = Math.Max(best, f[i]);
        }

        return best;
    }
}