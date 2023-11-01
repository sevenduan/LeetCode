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
public class SolutionMaxPathSum {
    int max = int.MinValue;
    public int MaxPathSum(TreeNode root) {
        if (root == null)
            return 0;

        helper(root);

        return max;
    }
    
    private int helper(TreeNode root) {
        if (root == null)
            return 0;
        
        int left = Math.Max(0, helper(root.left));
        int right = Math.Max(0, helper(root.right));
        
        int sum = Math.Max(left, right) + root.val;
        max = Math.Max(max, Math.Max(left + right + root.val, sum));
        
        return sum;
    }
}