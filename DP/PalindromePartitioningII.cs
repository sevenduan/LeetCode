public class SolutionMinCut
{
    private bool[,] GetPalindrome(string s)
    {
        int n = s.Length;
        bool[,] isPalindrome = new bool[n, n];

        for (int i = 0; i < n; i++)
        {
            isPalindrome[i, i] = true;
        }

        for (int i = 0; i < n - 1; i++)
        {
            if (s[i] == s[i + 1])
                isPalindrome[i, i + 1] = true;
            else
                isPalindrome[i, i + 1] = false;
        }

        for (int length = 2; length < n; length++)
        {
            for (int start = 0; start + length < n; start++)
            {
                if (s[start] == s[start + length] && isPalindrome[start + 1, start + length - 1])
                    isPalindrome[start, start + length] = true;
                else
                    isPalindrome[start, start + length] = false;
            }
        }

        return isPalindrome;
    }

    public int MinCut(string s)
    {
        if (string.IsNullOrEmpty(s))
            return 0;

        bool[,] isPalindrome = GetPalindrome(s);
        int n = s.Length;
        int[] f = new int[n + 1];

        // init
        f[0] = 0;
        // for (int i = 0; i <= n; i++) {
        //     f[i] = i;
        // }

        // main
        for (int i = 1; i <= n; i++)
        {
            f[i] = i;
            for (int j = 0; j < i; j++)
            {
                if (isPalindrome[j, i - 1])
                {
                    f[i] = Math.Min(f[i], f[j] + 1);
                }
            }
        }

        return f[n] - 1;
    }
}