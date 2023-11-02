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
public class SolutionIsValidBST {
    public bool IsValidBST(TreeNode root) {
        return DivideConquer(root).IsValidBST;
    }

    private (bool IsValidBST, TreeNode MaxNode, TreeNode MinNode) DivideConquer(TreeNode root) {
        if (root == null)
            return (true, null, null);

        var left = DivideConquer(root.left);
        var right = DivideConquer(root.right);

        if (!left.IsValidBST || !right.IsValidBST)
            return (false, null, null);
        
        if (left.MaxNode != null && left.MaxNode.val >= root.val) {
            return (false, null, null);
        }
        
        if (right.MinNode != null && right.MinNode.val <= root.val) {
            return (false, null, null);
        }

        TreeNode maxNode = right.MaxNode != null ? right.MaxNode : root;
        TreeNode minNode = left.MinNode != null ? left.MinNode : root;
    
        return (true, maxNode, minNode);
    }
}