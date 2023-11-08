public class SolutionPermute {
    public IList<IList<int>> Permute(int[] nums) {
        if (nums == null || nums.Length == 0)
            return null;
        
        IList<IList<int>> result = new List<IList<int>>();
        IList<int> list = new List<int>();

        SubsetsHelper(result, list, nums);
        return result;
    }

    private void SubsetsHelper(IList<IList<int>> result, IList<int> list, int[] nums) {
        if (list.Count == nums.Length) {
            result.Add(new List<int>(list));
            return;
        }
        
        for (int i = 0; i < nums.Length; i++) {
            if (list.Contains(nums[i]))
                continue;

            list.Add(nums[i]);
            SubsetsHelper(result, list, nums);
            list.RemoveAt(list.Count - 1);
        }
    }
}