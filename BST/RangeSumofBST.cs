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
public class SolutionRangeSumBST {
    public int RangeSumBST(TreeNode root, int low, int high) {
        int sum = 0;
        Travel(root, low, high, ref sum);
        return sum;
    }

    private void Travel(TreeNode root, int low, int high, ref int sum) {
        if (root == null) {
            return;
        }
        if (root.val > low)
            Travel(root.left, low, high, ref sum);
        if (root.val < high)
            Travel(root.right, low, high, ref sum);
        if (low <= root.val && root.val <= high)
            sum = sum + root.val;
    }
}