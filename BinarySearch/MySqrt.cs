//https://leetcode.com/problems/sqrtx/
public class SolutionMySqrt {
    public int MySqrt(int x) {
        if (x == 0 || x == 1)
            return x;
        
        long start = 1;
        long end = x;

        while (start + 1 < end) {
            long mid = start + (end - start) / 2;

            if (mid * mid == x)
                return (int)mid;
            
            if (mid * mid < x)
                start = (int)mid;
            else
                end = (int)mid;
        }

        if (end * end < x)
            return (int)end;
        else
            return (int)start;        
    }
}