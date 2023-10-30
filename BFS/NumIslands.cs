public class SolutionNumIslands {
    int[] deltaX = {0, 1, -1, 0};
    int[] deltaY = {1, 0, 0, -1};

    public int NumIslands(char[][] grid) {
        if (grid == null || grid.Length == 0 || grid[0] == null || grid[0].Length == 0) {
            return 0;
        }
        int islands = 0;
        int row = grid.Length;
        int col = grid[0].Length;
        bool[,] visited = new bool[row, col];

        for (int i = 0; i < row; i++) {
            for (int j = 0; j < col; j++) {
                if (grid[i][j] == '1' && !visited[i, j]) {
                    islands++;
                    BFS(grid, i, j, visited);
                }
            }
        }
        
        return islands;
    }

    private void BFS(char[][] grid, int row, int col, bool[,] visited)
    {
        Queue<int[]> queue = new Queue<int[]>();
        queue.Enqueue(new int[] { row, col });
        visited[row, col] = true;

        while (queue.Count > 0)
        {
            int[] cell = queue.Dequeue();

            //four directions
            for (int i = 0; i < 4; i++)
            {
                int newRow = cell[0] + deltaX[i];
                int newCol = cell[1] + deltaY[i];

                if (isValid(grid, newRow, newCol, visited))
                {
                    queue.Enqueue(new int[] { newRow, newCol });
                    visited[newRow,newCol] = true;
                }
            }
        }
    }

    private bool isValid(char[][] grid, int row, int col, bool[,] visited)
    {
        int n = grid.Length;
        int m = grid[0].Length;

        if (row < 0 || row >=n || col < 0 || col >= m)
            return false;
        
        if (visited[row, col])
            return false;
        
        return grid[row][col] == '1';
    }
}