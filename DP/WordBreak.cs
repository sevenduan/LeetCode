public class SolutionWordBreak {
    private int GetMaxLength(IList<string> wordDict) {
        int maxLength = 0;
        foreach (var word in wordDict) {
            maxLength = Math.Max(maxLength, word.Length);
        }

        return maxLength;
    }

    public bool WordBreak(string s, IList<string> wordDict) {
        if (string.IsNullOrEmpty(s))
            return true;

        int n = s.Length;
        int maxLength = GetMaxLength(wordDict);
        bool[] f = new bool[n + 1];
        // init
        f[0] = true;

        HashSet<string> dict = new HashSet<string>(wordDict);

        for (int i = 1; i <= n; i++) {
            f[i] = false;
            for (int j = 1; j <= maxLength && j <= i; j++) {
                if (!f[i - j])
                    continue;
                var word = s.Substring(i - j, j);
                if (dict.Contains(word)) {
                    f[i] = true;
                    break;
                }
            }
        }

        return f[n];
    }
}