public class SolutionPancakeSort {
    public IList<int> PancakeSort(int[] arr) {
        List<int> result = new List<int>();
        if (arr == null || arr.Length == 0)
            return result;
        
        int n = arr.Length;
        for (int i = n - 1; i > 0; i--) {
            int max = 0;

            for (int j = 1; j <= i; j++) {
                if (arr[j] > arr[max])
                    max = j;
            }

            if (max != 0 && max != i) {
                Flip(arr, max);
                Flip(arr, i);
                result.Add(max + 1);
                result.Add(i + 1);
            } else if (max ==0) {
                Flip(arr, i);
                result.Add(i + 1);
            }
        }

        return result;
    }
    
    private void Flip(int[] arr, int end)
    {
        int start = 0;
        while (start < end)
        {
            int temp = arr[start];
            arr[start] = arr[end];
            arr[end] = temp;
            start++;
            end--;
        }
    }
}