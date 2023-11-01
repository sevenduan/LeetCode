/* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */

public class Solution : VersionControl {
    public int FirstBadVersion(int n) {        
        int start = 1;
        int end = n;

        while (start + 1 < end) {
            int mid = start + (end - start) / 2;
            if (IsBadVersion(mid))
                end = mid;
            else
                start = mid;
        }

        if (IsBadVersion(start))
            return start;
        else
            return end;
    }
}