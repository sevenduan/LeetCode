public class Solution3 {
    public IList<int> FindClosestElements(int[] arr, int k, int x) {
        if (arr == null || arr.Length ==0)
            return arr;
        
        int left = FindLowerClosest(arr, x);
        int right = left + 1;

        List<int> result = new List<int>();

        for (int i = 0; i < k; i++){
            if (IsLeftCloser(arr, x, left, right)){
                result.Add(arr[left]);
                left--;
            } else {
                result.Add(arr[right]);
                right++;
            }
        }
        
        result = result.OrderBy(num => num).ToList();
        return result;
    }

    private bool IsLeftCloser(int[] arr, int target, int left, int right)
    {
        if (left < 0)
            return false;
        
        if (right >= arr.Length)
            return true;
        
        return target - arr[left] <= arr[right] - target;
    }

    private int FindLowerClosest(int[] arr, int target)
    {
        int start = 0;
        int end = arr.Length - 1;

        while(start + 1 < end){
            int mid = start + (end - start) / 2;

            if (arr[mid] < target)
                start = mid;
            else
                end = mid;          
        }

        if (arr[end] < target)
            return end;
        
        if (arr[start] < target)
            return start;
        
        return -1;        
    }
}