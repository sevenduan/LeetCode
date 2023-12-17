public class SolutionLongestCommonSubsequence {
    public int LongestCommonSubsequence(string text1, string text2) {
        if (string.IsNullOrEmpty(text1) || string.IsNullOrEmpty(text2))
            return 0;

        int m = text1.Length;
        int n = text2.Length;

        int[,] f = new int[m + 1, n + 1];
        
        for (int i = 1; i <= m; i++) {
            for (int j = 1; j <= n; j++) {
                f[i, j] = Math.Max(f[i - 1, j], f[i, j - 1]);
                if (text1[i - 1] == text2[j - 1]) {
                    f[i, j] = Math.Max(f[i, j], f[i - 1, j - 1] + 1);
                }
            }
        }

        return f[m, n];
    }
}

// Rolling array
public class SolutionLongestCommonSubsequenceRolling {
    public int LongestCommonSubsequence(string text1, string text2) {
        if (string.IsNullOrEmpty(text1) || string.IsNullOrEmpty(text2))
            return 0;
        
        int n = text1.Length;
        int m = text2.Length;

        int[,] dp = new int[2, m + 1];
        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= m; j++) {
                dp[i % 2, j] = Math.Max(dp[(i - 1) % 2, j], dp[i % 2, j - 1]);
                if (text1[i - 1] == text2[j - 1]) {
                    dp[i % 2, j] = Math.Max(dp[i % 2, j], dp[(i - 1) % 2, j - 1] + 1);
                }
            }
        }

        return dp[n % 2, m];
    }
}