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
public class SolutionInorderTraversal {
    public IList<int> InorderTraversal(TreeNode root) {        
        List<int> inorder = new List<int>();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        if (root == null)
            return inorder;

        while (root != null) {
            stack.Push(root);
            root = root.left;
        }
        
        while (stack.Count > 0) {
            TreeNode node = stack.Pop();
            inorder.Add(node.val);

            if (node.right != null) {
                node = node.right;
                while (node != null) {
                    stack.Push(node);
                    node = node.left;
                }
            }
        }

        return inorder;
    }
}