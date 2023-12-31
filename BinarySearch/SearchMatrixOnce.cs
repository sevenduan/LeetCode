public class SolutionOnce {
    public bool SearchMatrix(int[][] matrix, int target) {
        if (matrix == null || matrix.Length == 0)
            return false;

        if (matrix[0] == null || matrix[0].Length == 0)
            return false;
        
        //binary search row
        int row = matrix.Length;
        int column = matrix[0].Length;

        int start = 0, end = row * column - 1;

        while (start + 1 < end) {
            int mid = start + (end - start) / 2;

            int number = matrix[mid / column][mid % column];

            if (number == target)
                return true;
            
            if (number < target)
                start = mid;
            else
                end = mid;
        }
        
        if (matrix[start / column][start % column] == target)
            return true;

        if (matrix[end / column][end % column] == target)
            return true;
        
        return false;
    }
}