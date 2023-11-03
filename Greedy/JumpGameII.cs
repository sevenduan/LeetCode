public class SolutionJumpII {
    public int Jump(int[] nums) {        
        int[] steps = new int[nums.Length];
        //init
        int start = 0, end = 0, jumps = 0;

        while (end < nums.Length - 1) {
            jumps++;
            int farthest = end;
            for (int i = start; i <= end; i++) {
                if (nums[i] + i > farthest) {
                    farthest = nums[i] + i;
                }
            }
            start = end + 1;
            end = farthest;
        }
        return jumps;
    }
}