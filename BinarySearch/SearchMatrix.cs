public class SolutionSearchMatrix {
    public bool SearchMatrix(int[][] matrix, int target) {
        
        if (matrix == null || matrix.Length == 0 || matrix[0] == null || matrix[0].Length == 0) {
            return false;
        }

        int row = matrix.Length;
        int column = matrix[0].Length;

        // find the row index, the last number <= target 

        int start = 0;
        int end = row - 1;

        while (start + 1 < end)
        {
            int mid = start + (end - start) / 2;

            if (matrix[mid][0] == target)
                return true;
            else if (matrix[mid][0] < target)
                start = mid;
            else
                end = mid;
        }
        if (matrix[end][0] <= target)
            row = end;
        else if (matrix[start][0] <= target)
            row = start;
        else
            return false;        


        // find the column index, the number equal to target
        start = 0;
        end = column - 1;
        while (start + 1 < end)
        {
            int mid = start + (end - start) / 2;
            if (matrix[row][mid] == target)
                return true;
            else if (matrix[row][mid] < target)
                start = mid;
            else
                end = mid;
        }

        if (matrix[row][start] == target) {
            return true;
        } else if (matrix[row][end] == target) {
            return true;
        }
        return false;
    }
}