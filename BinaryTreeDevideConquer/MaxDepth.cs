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
public class SolutionMaxDepth {
    public int MaxDepth(TreeNode root) {
        if (root == null)
            return 0;
        
        int maxLeft = MaxDepth(root.left);
        int maxRight = MaxDepth(root.right);

        return Math.Max(maxLeft, maxRight) + 1;
    }
}