public class SolutionFourSum {
    public IList<IList<int>> FourSum(int[] nums, int target) {
        List<IList<int>> results = new List<IList<int>>();
        if (nums==null || nums.Length < 4)
            return results;
        
        Array.Sort(nums);

        for (int i = 0; i < nums.Length - 3; i++) {
            if (i > 0 && nums[i] == nums[i-1])
                continue;
            
            for (int j = i + 1; j < nums.Length - 2; j++) {
                if(j > i + 1 && nums[j] == nums[j-1])
                    continue;
                
                long sum = nums[i] + nums[j];
                Find2Sum(nums, i, j, (long)target - sum, results);
            }
        }

        return results;
    }

    private void Find2Sum(int[] nums, int index1, int index2, long target, IList<IList<int>> results) {
        int left = index2 + 1;
        int right = nums.Length - 1;
        while (left < right) {
            long sum = nums[left] + nums[right];

            if (sum == target) {
                List<int> temp = new List<int>();
                temp.Add(nums[index1]);
                temp.Add(nums[index2]);
                temp.Add(nums[left]);
                temp.Add(nums[right]);
                results.Add(new List<int>(temp));
                left++;
                right--;
                while (left < right && nums[left] == nums[left - 1])
                    left++;
                while (left < right && nums[right] == nums[right + 1])
                    right--;
            } else if (sum > target) {
                right--;
            } else {
                left++;
            }
        }
    }

}