public class SolutionMinimumTotal {
    public int MinimumTotal(IList<IList<int>> triangle) {
        int n = triangle.Count;

        int[,] f = new int[n,n];

        f[0, 0] = triangle[0][0];
        for (int i = 1; i < n; i++) {
            f[i, 0] = f[i - 1, 0] + triangle[i][0];
            f[i, i] = f[i - 1, i - 1] + triangle[i][i];
        }

        for (int i = 1; i < n; i++) {
            for (int j = 1; j < i; j++) {
                f[i, j] = Math.Min(f[i - 1, j], f[i - 1, j - 1]) + triangle[i][j];
            }
        }

        int answer = int.MaxValue;
        for (int i = 0; i < n; i++) {
            answer = Math.Min(answer, f[n-1, i]);
        }

        return answer;
    }
}