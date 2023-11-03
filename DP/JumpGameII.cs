public class SolutionJump {
    public int Jump(int[] nums) {        
        int[] steps = new int[nums.Length];
        //init
        steps[0] = 0;
        for (int i = 1; i < nums.Length; i++) {
            steps[i] = int.MaxValue;
        }

        // function
        for (int i = 1; i < nums.Length; i++) {
            for (int j = 0; j < i; j++) {
                if (steps[j] != int.MaxValue && j + nums[j] >= i) {
                    steps[i] = Math.Min(steps[i], steps[j] + 1);
                    break;
                }
            }
        }

        return steps[nums.Length - 1];
    }
}