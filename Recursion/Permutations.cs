//https://leetcode.com/problems/permutations/
public class SolutionPermute {
    public IList<IList<int>> Permute(int[] nums) {
        if (nums == null || nums.Length == 0)
            return null;
        
        IList<IList<int>> result = new List<IList<int>>();
        IList<int> list = new List<int>();
        bool[] used = new bool[nums.Length];

        SubsetsHelper(result, list, used, nums);
        return result;
    }

    private void SubsetsHelper(IList<IList<int>> result, IList<int> list, bool[] used, int[] nums) {
        if (list.Count == nums.Length)
            result.Add(new List<int>(list));
        
        for (int i = 0; i < nums.Length; i++) {
            if (!used[i])
            {
                used[i] = true;
                list.Add(nums[i]);
                SubsetsHelper(result, list, used, nums);
                list.RemoveAt(list.Count - 1);
                used[i] = false;
            }
        }
    }
}