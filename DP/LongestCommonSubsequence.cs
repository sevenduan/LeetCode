public class SolutionLongestCommonSubsequence {
    public int LongestCommonSubsequence(string text1, string text2) {
        if (string.IsNullOrEmpty(text1) || string.IsNullOrEmpty(text2))
            return 0;

        int m = text1.Length;
        int n = text2.Length;

        int[,] f = new int[m + 1, n + 1];

        for (int i = 0; i <= m; i++) {
            f[i, 0] = 0;
        }
        for (int i = 0; i <= n; i++) {
            f[0, i] = 0;
        }
        
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