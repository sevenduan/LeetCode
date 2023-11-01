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
public class SolutionPostorderTraversal {
    public IList<int> PostorderTraversal(TreeNode root) {
        List<int> postorder = new List<int>();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode prev = null; // previously traversed node
        TreeNode curr = root;
        if (root == null)
            return postorder;

        stack.Push(root);

        while (stack.Count > 0) {
            curr = stack.Peek();            
            
            if (prev == null || prev.left == curr || prev.right == curr) { // traverse down the tree
                if (curr.left != null) {
                    stack.Push(curr.left);
                } else if (curr.right != null) {
                    stack.Push(curr.right);
                }
            } else if (curr.left == prev) { // traverse up the tree from the left
                if (curr.right != null) {
                    stack.Push(curr.right);
                }
            } else { // traverse up the tree from the right
                postorder.Add(curr.val);
                stack.Pop();
            }
            prev = curr;
        }

        return postorder;
    }
}