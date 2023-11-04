public class SolutionNumDistinct {
    public int NumDistinct(string s, string t) {
        if (s == null || t == null)
            return 0;
        
        int m = s.Length;
        int n = t.Length;
        int[,] f = new int[m + 1, n + 1];

        for (int i = 0; i <= m; i++) {
            f[i, 0] = 1;
        }

        for (int j = 1; j <= n; j++) {
            f[0, j] = 0;
        }

        //
        for (int i = 1; i <= m; i++) {
            for (int j = 1; j <= i && j <= n; j++) {
                if (s[i - 1] != t[j - 1]){
                    f[i, j] = f[i - 1, j];
                } else {
                    f[i, j] = f[i - 1, j] + f[i - 1, j - 1];
                }
            }
        }

        return f[m, n];
    }
}