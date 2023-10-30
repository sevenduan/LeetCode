//https://leetcode.com/problems/subsets/
public class SolutionSubsets {
    public IList<IList<int>> Subsets(int[] nums) {
        if (nums == null || nums.Length == 0)
            return null;
        
        IList<IList<int>> results = new List<IList<int>>();
        IList<int> list = new List<int>();
        
        SubsetsHelper(results, list, nums, 0);
        return results;
    }

    private void SubsetsHelper(IList<IList<int>> results, IList<int> list, int[] nums, int pos) {
        results.Add(new List<int>(list));
        for (int i = pos; i < nums.Length; i++) {
            list.Add(nums[i]);
            SubsetsHelper(results, list, nums, i + 1);
            list.RemoveAt(list.Count - 1);
        }
    }
}