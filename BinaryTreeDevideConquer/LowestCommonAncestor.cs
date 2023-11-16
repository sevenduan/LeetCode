// https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

public class SolutionLCA {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if (root == null)
            return null;

        if (root == p || root == q)
            return root;

        TreeNode left = LowestCommonAncestor(root.left, p, q);

        TreeNode right = LowestCommonAncestor(root.right, p, q);

        if (left != null && right != null)
            return root;
        
        if (left != null)
            return left;
        
        if (right != null)
            return right;
        
        return null;
    }
}