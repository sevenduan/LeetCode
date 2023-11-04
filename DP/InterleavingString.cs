public class SolutionIsInterleave {
    public bool IsInterleave(string s1, string s2, string s3) {
        if (s1 == null || s2 == null || s3 == null)
            return false;
        
        int m = s1.Length;
        int n = s2.Length;

        if (m + n != s3.Length)
            return false;
        
        bool[,] f = new bool[m + 1, n + 1];
        // init
        f[0, 0] = true;
        for (int i = 1; i <= m; i++) {
            if (s1[i - 1] == s3[i - 1] && f[i - 1, 0])
                f[i, 0] = true;
        }

        // init f[0, j]
        for (int i = 1; i <= n; i++) {
            if (s2[i - 1] == s3[i - 1] && f[0, i - 1])
                f[0, i] = true;
        }

        // dp
        for (int i = 1; i <= m; i++) {
            for (int j = 1; j <= n; j++) {
                if ((s1[i - 1] == s3[i + j - 1] && f[i - 1, j]) || (s2[j - 1] == s3[i + j - 1] && f[i, j - 1])) {
                    f[i, j] = true;
                }
            }
        }

        return f[m, n];
    }
}