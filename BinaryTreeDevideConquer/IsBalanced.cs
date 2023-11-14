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
 class ResultType {
    public bool isBalanced;
    public int maxDepth;
    public ResultType(bool isBalanced, int maxDepth) {
        this.isBalanced = isBalanced;
        this.maxDepth = maxDepth;
    }
}
public class SolutionIsBalanced {
    public bool IsBalanced(TreeNode root) {
        var result = MaxDepth(root);

        return result.isBalanced;
    }

    private ResultType MaxDepth(TreeNode root)
    {
        if (root == null)
        {
            return new ResultType(true, 0);
        }

        var left = MaxDepth(root.left);
        var right = MaxDepth(root.right);

        int height = Math.Max(left.maxDepth, right.maxDepth) + 1;
        bool isBalanced = true;

        if (!left.isBalanced || !right.isBalanced) {
            isBalanced = false;;
        }

        if (Math.Abs(left.maxDepth - right.maxDepth) > 1) {
            isBalanced = false;;
        }
        
        return new ResultType(isBalanced, height);
    }
}