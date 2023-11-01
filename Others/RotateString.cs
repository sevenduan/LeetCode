public class SolutionRotateString {
    public bool RotateString(string s, string goal) {
        if (string.IsNullOrEmpty(s))
            return false;
        
        if (s.Length != goal.Length)
            return false;

        //
        string source = s + s;

        int i;
        int j;

        for (i = 0; i < goal.Length; i ++) {
            for (j = 0; j < goal.Length; j++) {
                if (source[i + j] != goal[j])
                    break;
            }

            if (j == goal.Length)
                return true;
        }

        return false;
    }
}