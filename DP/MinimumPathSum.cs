//https://leetcode.com/problems/minimum-path-sum/
public class SolutionMinPathSum {
    public int MinPathSum(int[][] grid) {
        if (grid == null || grid.Length == 0 || grid[0] == null || grid[0].Length == 0)
            return 0;

        int row = grid.Length;
        int column = grid[0].Length;

        // Initialize
        int[,] dp = new int[row, column];

        dp[0, 0] = grid[0][0];
        
        // Initialize the values in the first row and the first column
        for (int i = 1; i < row; i++) {
            dp[i, 0] = dp[i - 1, 0] + grid[i][0];
        }

        for (int j = 1; j < column; j++) {
            dp[0, j] = dp[0, j - 1] + grid[0][j];
        }
        
        for (int i = 1; i < row; i++) {
            for (int j = 1; j < column; j++) {
                dp[i, j] = Math.Min(dp[i - 1, j], dp[i, j - 1]) + grid[i][j];
            }
        }

        return dp[row - 1, column - 1];
    }
}