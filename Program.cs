namespace LeetCode;

class Program
{
    private static int Aplusb(int a, int b)
    {
        // write your code here
        if (a == 0)
            return b;
        if (a == 0)
            return a;

        int sum, i;
        i = a ^ b;
        sum = (a & b) << 1;
        Console.WriteLine(i);
        Console.WriteLine(sum);
        return Aplusb(sum, i);
    }

    private static void SortColors2(int[] nums, int target) {
        if (nums == null || nums.Length == 0) {
            return;
        }


        RainbowSort(nums, 0, nums.Length - 1, 1, target);
    }

    private static void RainbowSort(int[] colors, int start, int end, int colorFrom, int colorTo) {
        if (colorFrom == colorTo) {
            return;
        }
        
        if (start >= end) {
            return;
        }
        
        int left = start;
        int right = end;
        int colorMid = (colorFrom + colorTo) / 2;
        
        while (left <= right) {
            while (left <= right && colors[left] <= colorMid) {
                left++;
            }
            while (left <= right && colors[right] >= colorMid) {
                right--;
            }

            if (left <= right) {
                Swap(colors, left, right);
                left++;
                right--;
            }
        }
        RainbowSort(colors, start, right, colorFrom, colorMid);
        RainbowSort(colors, left, end, colorMid + 1, colorTo);
    }

    private static void Swap(int[] nums, int left, int right) {
        int temp = nums[left];
        nums[left] = nums[right];
        nums[right] = temp;
    }

    static void Main(string[] args)
    {
        
        int[] nums = new int[] { 3, 2, 2, 1, 4 };
        SortColors2(nums, 4);

        Console.WriteLine(string.Join(',', nums));

        // int[] nums = new int[] { 1, 2, 3, 4, 5 , 5}; 
        // int n = nums.Length;
        // Dictionary<int, int> map = new Dictionary<int, int>();
        // int answer = 0;
        // int prefixSum = 0;
        // map[0] = 1;

        // for (int i = 0; i < n; i++) {
        //     prefixSum += nums[i];

        //     Console.WriteLine("prefixSum: " + prefixSum);
        //     if (map.ContainsKey(prefixSum - 7)) {
        //         answer += map[prefixSum - 7];
        //         Console.WriteLine("answer: " + answer);
        //     }

        //     if (map.ContainsKey(prefixSum)) {
        //         map[prefixSum]++;
        //     } else {
        //         map[prefixSum] = 1;
        //     }
        // }

        // Console.WriteLine("answer: " + answer);

        // List<int> minLast = new List<int>();
        // minLast.Add(nums[0]);

        //  for (int i = 1; i < nums.Length; i++) {
        //     if (nums[i] > minLast[minLast.Count - 1]) {
        //         minLast.Add(nums[i]);
        //     } else {
        //         //find ans[low] < nums[i] < ans[low] 
        //         int low = BinarySearch(minLast, nums[i]);
        //         Console.WriteLine("i:" + low);
        //         minLast[low] = nums[i];
        //     }
        // }
        // Console.WriteLine(string.Join(",", minLast));
        Console.WriteLine("Hello, World!");
    }


    private static int BinarySearch(IList<int> ans, int target) {
        // find first > target
        int start = 0;
        int end = ans.Count - 1;

        while (start + 1 < end) {
            int middle = (start + end) / 2;

            if (ans[middle] < target) {
                start = middle;
            } else {
                end = middle;
            }
        }

        Console.WriteLine(string.Join(",", ans));
        Console.WriteLine(start);
        Console.WriteLine(target);
        Console.WriteLine(end);
        if (ans[start] >= target)
            return start;
        else if (ans[end] >= target)
            return end;
        else
            return 0;
    } 
}
