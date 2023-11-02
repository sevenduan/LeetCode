/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class SolutionLevelOrderDFS {
    public IList<IList<int>> LevelOrder(TreeNode root) {
        List<IList<int>> result = new List<IList<int>>();

        if (root == null) {
            return result;
        }

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        int maxLevel = 0;
        while (true)
        {
            List<int> level = new List<int>();
            DFS(root, level, 0, maxLevel);
            if (level.Count == 0) {
                break;
            }            
            result.Add(new List<int>(level));
            maxLevel++;
        }

        return result;
    }

    private void DFS(TreeNode root,
                     List<int> level,
                     int curtLevel,
                     int maxLevel) {
        if (root == null || curtLevel > maxLevel) {
            return;
        }
        
        if (curtLevel == maxLevel) {
            level.Add(root.val);
            return;
        }
        
        DFS(root.left, level, curtLevel + 1, maxLevel);
        DFS(root.right, level, curtLevel + 1, maxLevel);
    }
}