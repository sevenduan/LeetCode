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

// Rolling Array
public class SolutionRolling {
    public int MinimumTotal(IList<IList<int>> triangle) {
        int n = triangle.Count;

        int[,] f = new int[2,n];

        f[0, 0] = triangle[0][0];

        for (int i = 1; i < n; i++) {
            int m = i % 2;
            f[m, 0] = f[1 - m, 0] + triangle[i][0];
            f[m, i] = f[1 - m, i - 1] + triangle[i][i];
            for (int j = 1; j < i; j++) {
                f[m, j] = Math.Min(f[1 - m, j], f[1 - m, j - 1]) + triangle[i][j];
            }
        }

        int last = (n - 1) % 2;
        int answer = f[last, 0];
        for (int i = 1; i < n; i++) {
            answer = Math.Min(answer, f[last, i]);
        }

        return answer;
    }
}
