public class SolutionStrStr {
    public int StrStr(string haystack, string needle) {
        if (haystack == null || needle == null)
            return -1;
        
        int i;
        int j;

        for (i = 0; i < haystack.Length - needle.Length + 1; i++)
        {
            for (j =0; j < needle.Length; j++)
            {
                if (haystack[i + j] != needle[j])
                    break;
            }

            if (j == needle.Length)
                return i;
        }
        
        return -1;
    }
}