//https://leetcode.com/problems/permutations-ii/
public class SolutionPermuteUnique {
    public IList<IList<int>> PermuteUnique(int[] nums) {      
        IList<IList<int>> result = new List<IList<int>>();  
        if (nums == null || nums.Length == 0)
            return result;

        //sort
        Array.Sort(nums);
        IList<int> list = new List<int>();
        bool[] used = new bool[nums.Length];

        SubsetsHelper(result, list, used, nums);

        return result;
    }

    private void SubsetsHelper(IList<IList<int>> result, IList<int> list, bool[] used, int[] nums) {
        if (list.Count == nums.Length) {
            result.Add(new List<int>(list));
        }
        
        for (int i = 0; i < nums.Length; i++)
        {
            if (used[i])
                continue;

            if (i > 0 && nums[i] == nums[i-1] && !used[i-1])
                continue;

            used[i] = true;
            list.Add(nums[i]);
            SubsetsHelper(result, list, used, nums);
            list.RemoveAt(list.Count - 1);
            used[i] = false;
        }
    }
}