public class SolutionDFS {
    public IList<IList<int>> Subsets(int[] nums) {
        List<IList<int>> results = new List<IList<int>>();
        // 2^n
        if (nums == null)
            return results;

        if (nums.Length == 0)
        {
            results.Add(new List<int>()); // Add an empty subset
            return results;
        }
        
        DFS(nums, 0, new List<int>(), results);
        return results;
    }

    private void DFS(int[] nums, int index, List<int> subset, List<IList<int>> results)
    {
        //exit
        if (index == nums.Length)
        {
            results.Add(new List<int>(subset));
            return;
        }

        //recursion
        subset.Add(nums[index]);
        DFS(nums, index + 1, subset, results);

        //no nums[index]
        subset.RemoveAt(subset.Count - 1);
        DFS(nums, index + 1, subset, results);
    }
}