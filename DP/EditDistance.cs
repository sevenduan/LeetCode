public class SolutionMinDistance {
    public int MinDistance(string word1, string word2) {
        if (string.IsNullOrEmpty(word1) && string.IsNullOrEmpty(word2))
            return 0;
        
        if (string.IsNullOrEmpty(word1))
            return word2.Length;
        
        if (string.IsNullOrEmpty(word2))
            return word1.Length;
        
        int m = word1.Length;
        int n = word2.Length;

        int[,] f = new int[m + 1, n + 1];

        for (int i = 0; i <= m; i++) {
            f[i, 0] = i;
        }

        for (int i = 0; i <= n; i++) {
            f[0, i] = i;
        }

        for (int i = 1; i <= m; i++) {
            for (int j = 1; j <= n; j++){
                f[i, j] = Math.Min(f[i - 1, j] + 1, f[i, j - 1] + 1);
                if (word1[i - 1] != word2[j - 1]) {
                    f[i, j] = Math.Min(f[i, j], f[i - 1, j - 1] + 1);
                } else {
                    f[i, j] = Math.Min(f[i, j], f[i - 1, j - 1]);
                }
            }
        }

        return f[m, n];
    }
}


// rolling array
public class SolutionMinDistanceRolling {
    public int MinDistance(string word1, string word2) {        
        if (string.IsNullOrEmpty(word1) && string.IsNullOrEmpty(word2))
            return 0;
        
        if (string.IsNullOrEmpty(word1))
            return word2.Length;
        
        if (string.IsNullOrEmpty(word2))
            return word1.Length;
        
        int n = word1.Length;
        int m = word2.Length;
        int[,] dp = new int[n + 1, m + 1];

        for (int j = 0; j <= m; j++) {
            dp[0, j] = j;
        }

        for (int i = 1; i <= n; i++) {
            dp [i % 2, 0] = i;
            for (int j = 1; j <=m; j++) {
                dp[i % 2, j] = Math.Min(dp[(i - 1) % 2, j], dp[i % 2, j - 1]) + 1;

                if (word1[i - 1] == word2[j - 1]) {
                    dp[i % 2, j] = Math.Min(dp[i % 2, j], dp[(i - 1) % 2, j - 1]);
                } else {
                    dp[i % 2, j] = Math.Min(dp[i % 2, j], dp[(i - 1) % 2, j - 1] + 1);
                }
            }
        }

        return dp[n % 2, m];
    }
}