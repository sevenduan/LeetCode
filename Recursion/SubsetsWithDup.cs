//https://leetcode.com/problems/subsets-ii/
public class SolutionSubsetsWithDup {
    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        if (nums == null  || nums.Length == 0)
            return null;
        
        //sort
        Array.Sort(nums);
        IList<IList<int>> result = new List<IList<int>>();
        IList<int> list = new List<int>();
        SubsetsHelper(result, list, nums, 0);
        return result;
    }

    private void SubsetsHelper(IList<IList<int>> result, IList<int> list, int[] nums, int pos) {
        result.Add(new List<int>(list));
        for (int i = pos; i < nums.Length; i++)
        {
            if (i != pos && nums[i] == nums[i - 1]) {
                continue;
            }
            list.Add(nums[i]);
            SubsetsHelper(result, list, nums, i + 1);
            list.RemoveAt(list.Count - 1);
        }
    }
}