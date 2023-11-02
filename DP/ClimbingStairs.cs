//https://leetcode.com/problems/climbing-stairs/ 
public class SolutionClimbStairs {
    public int ClimbStairs(int n) {
        if (n <= 0) {
            return 0;
        }
        if (n == 1) {
            return 1;
        }
        if (n == 2) {
            return 2;
        }
        
        int[] f = new int[n + 1];
        f[0] = 0;
        f[1] = 1;
        f[2] = 2;

        for (int i = 3; i < n + 1; i++) {
            f[i] = f[i-2] + f[i-1];
        }

        return f[n];
    }
}