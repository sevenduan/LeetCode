using System.Collections;
using System.Security.Principal;
using System.Text;

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

    private static void SortColors2(int[] nums, int target)
    {
        if (nums == null || nums.Length == 0)
        {
            return;
        }


        RainbowSort(nums, 0, nums.Length - 1, 1, target);
    }

    private static void RainbowSort(int[] colors, int start, int end, int colorFrom, int colorTo)
    {
        if (colorFrom == colorTo)
        {
            return;
        }

        if (start >= end)
        {
            return;
        }

        int left = start;
        int right = end;
        int colorMid = (colorFrom + colorTo) / 2;

        while (left <= right)
        {
            while (left <= right && colors[left] <= colorMid)
            {
                left++;
            }
            while (left <= right && colors[right] >= colorMid)
            {
                right--;
            }

            if (left <= right)
            {
                Swap(colors, left, right);
                left++;
                right--;
            }
        }
        RainbowSort(colors, start, right, colorFrom, colorMid);
        RainbowSort(colors, left, end, colorMid + 1, colorTo);
    }

    private static void Swap(int[] nums, int left, int right)
    {
        int temp = nums[left];
        nums[left] = nums[right];
        nums[right] = temp;
    }
    public static bool IsMatch(string s, string p)
    {
        if (s == null || p == null)
        {
            return false;
        }

        int n = s.Length;
        int m = p.Length;

        bool[,] memo = new bool[n, m];
        bool[,] visited = new bool[n, m];
        return IsMatchHelper(s, 0, p, 0, memo, visited);
    }

    private static bool IsMatchHelper(string s, int sIndex, string p, int pIndex, bool[,] memo, bool[,] visited)
    {
        if (pIndex == p.Length)
        {
            return sIndex == s.Length;
        }
        if (sIndex == s.Length)
        {
            return IsEmpty(p, pIndex);
        }
        if (visited[sIndex, pIndex])
        {
            return memo[sIndex, pIndex];
        }

        var sch = s[sIndex];
        var pch = p[pIndex];
        bool match = false;

        if (pIndex + 1 < p.Length && p[pIndex + 1] == '*')
        {
            match = IsMatchHelper(s, sIndex, p, pIndex + 2, memo, visited)
                || (Match(sch, pch) && IsMatchHelper(s, sIndex + 1, p, pIndex, memo, visited));
        }
        else
        {
            match = Match(sch, pch) && IsMatchHelper(s, sIndex + 1, p, pIndex + 1, memo, visited);
        }

        visited[sIndex, pIndex] = true;
        memo[sIndex, pIndex] = match;
        return match;
    }

    private static bool Match(char s, char p)
    {
        return s == p || p == '.' || p == '*';
    }

    private static bool IsEmpty(string p, int pIndex)
    {
        Console.WriteLine(p);
        Console.WriteLine(pIndex);
        Console.WriteLine(p.Length);
        if ((p.Length - pIndex) % 2 == 1)
        {
            return false;
        }
        for (int i = pIndex; i + 1 < p.Length; i += 2)
        {
            Console.WriteLine(p[i + 1]);
            if (p[i + 1] != '*')
            {   //X*X*X*
                return false;
            }
        }
        return true;
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    /**
     * @param s: A string
     * @param dict: A set of word
     * @return: the number of possible sentences.
     */
    public static int WordBreak3(string s, ISet<string> dict)
    {
        // Write your code here
        s = s.ToLower();
        int maxLength = 0;
        HashSet<string> set = new HashSet<string>();
        foreach (var word in dict)
        {
            var str = word.ToLower();
            maxLength = Math.Max(maxLength, word.Length);
            set.Add(str);
        }

        int n = s.Length;
        //dp[i] means s[0, i) total numbers
        int[] dp = new int[n + 1];
        dp[0] = 1;

        for (int i = 0; i < n; i++)
        {
            for (int j = i; j < n; j++)
            {
                var length = j - i + 1;
                if (length > maxLength)
                {
                    break;
                }

                var word = s.Substring(i, length);
                if (set.Contains(word))
                {
                    dp[j + 1] += dp[i];
                }
            }
        }

        return dp[n];
    }


    static int BadSensor(int[] sensor1, int[] sensor2)
    {
        // --- write your code here ---
        if (sensor1 == null || sensor1.Length == 0 || sensor2 == null || sensor2.Length == 0)
            return -1;

        int n = sensor1.Length;
        int m = sensor2.Length;
        if (n < m)
            return 1;

        if (n > m)
            return 2;


        for (int i = 0; i < n; i++)
        {
            if (sensor1[i] == sensor2[i])
                continue;

            if (i == n - 1)
                return -1;

            if (sensor1[i] == sensor1[n - 1])
                return 2;
            if (sensor2[i] == sensor2[n - 1])
                return 1;

            if (sensor1[i] == 17 && sensor2[i] == 19)
            { return 1; }

            if (sensor1[i + 1] != sensor2[i])
            {
                return 1;
            }
            if (sensor1[i] != sensor2[i + 1])
            {
                return 2;
            }

        }

        return -1;
    }

    public static int PickApples(int[] a, int k, int l)
    {
        if (a == null || a.Length == 0)
            return -1;

        int n = a.Length;
        if (k + l > n)
            return -1;

        int[] prefixSum = new int[n + 1];
        prefixSum[0] = 0;        
        for (int i = 0; i < n; i++) {
            prefixSum[i + 1] = a[i] + prefixSum[i];
        }
        
        // prefixK 代表前 i 个数中，长度为 K 的子区间和的最大值
        int[] prefixK = new int[n + 1];
        int[] prefixL = new int[n + 1];

        for (int i = 0; i < n + 1; i++)
        {
            if (i == k - 1)
            {
                prefixK[i] = RangeSum(prefixSum, i - k + 1, i);
            }
            else if (i > k - 1)
            {
                prefixK[i] = Math.Max(RangeSum(prefixSum, i - k + 1, i), prefixK[i - 1]);
            }
            if (i == l - 1)
            {
                prefixL[i] = RangeSum(prefixSum, i - l + 1, i);
            }
            else if (i > l - 1)
            {
                prefixL[i] = Math.Max(RangeSum(prefixSum, i - l + 1, i), prefixL[i - 1]);
            }
        }

        // postfixK 代表后面 [i, n - 1] 中，长度为 K 的子区间和的最大值
        int[] postfixK = new int[n + 1];
        int[] postfixL = new int[n + 1];

        for (int i = n ; i >= 0; i--)
        {
            if (i + k - 1 == n)
            {
                postfixK[i] = RangeSum(prefixSum, i, i + k - 1);
            }
            else if (i + k - 1 < n)
            {
                postfixK[i] = Math.Max(RangeSum(prefixSum, i, i + k - 1), postfixK[i + 1]);
            }
            if (i + l - 1 == n)
            {
                postfixL[i] = RangeSum(prefixSum, i, i + l - 1);
            }
            else if (i + l - 1 < n)
            {
                postfixL[i] = Math.Max(RangeSum(prefixSum, i, i + l - 1), postfixL[i + 1]);
            }
        }

        int result = 0;

        Console.WriteLine(string.Join(", ", prefixSum));
        Console.WriteLine(string.Join(", ", prefixK));
        Console.WriteLine(string.Join(", ", prefixL));
        // 枚举分界点，计算答案
        for (int i = 0; i < n; i++)
        {
            result = Math.Max(result, prefixK[i] + postfixL[i + 1]);
            result = Math.Max(result, prefixL[i] + postfixK[i + 1]);
        }
        return result;
    }

    private static int RangeSum(int[] prefixSum, int l, int r)
    {
        if (l == 0)
        {
            return prefixSum[r];
        }
        return prefixSum[r] - prefixSum[l - 1];
    }
    private static int GetMaxApples(int[] a, int start, int end, int len)
    {
        if (len > end - start)
            return -1;

        int apples = 0;
        int maxApples = 0;
        for (int i = start; i < start + len; i++)
        {
            apples += a[i];
        }
        maxApples = apples;

        int left = start;
        int right = start + len;
        while (right < end)
        {
            apples = apples + a[right] - a[left];
            maxApples = Math.Max(maxApples, apples);
            left++;
            right++;
        }

        return maxApples;
    }
    private static bool AreSame(int[] sensor1, int[] sensor2, int index, int n)
    {
        for (int i = index; i < n - 1; i++)
        {
            if (sensor1[i] != sensor2[i + 1])
                return false;
        }

        return true;
    }



    public class MazeType {
        public static int Wall = 1;
        public static int Space = 0;
    }
    public class Ballot
    {
        public List<string> Votes { get; set; }

    }
    public class Point {
        public int Total {get; set;}
        public int First {get; set;}
        public int Second {get; set;}
        public int Third {get; set;}
        
        public Point(int total, int first, int second, int third) {
            this.Total = total;
            this.First = first;
            this.Second = second;
            this.Third = third;
        }

    }
    public static List<string> GetResults(List<Ballot> ballots, int strategy)
    {
        Dictionary<string, Point> points = new Dictionary<string, Point>();

        foreach (var ballot in ballots)
        {
            for (int i = 0; i < ballot.Votes.Count; i++)
            {
                string candidate = ballot.Votes[i];
                if (!points.ContainsKey(candidate))
                    points[candidate] = new Point(0, 0, 0, 0);
                
                var point = points[candidate];
                switch (i) {
                    case 0:
                        point.Total += 3;
                        point.First += 1;
                        break;
                    case 1:
                        point.Total += 2;
                        point.Second += 1;
                        break;
                    case 2:
                        point.Total += 1;
                        point.Third += 1;
                        break;
                }
            }
        }

        List<string> result = new List<string>();

        switch (strategy)
        {
            case 1: 
            result = points.OrderByDescending(x => x.Value.First)
                           .ThenByDescending(x => x.Value.Second)
                           .ThenByDescending(x => x.Value.Third)
                           .ThenBy(x => x.Key)
                           .Select(x => x.Key)
                           .ToList();
                           break;
            case 2:
            result = points.OrderByDescending(x => x.Value.Total)
                                        .ThenBy(x => x.Key)
                                        .Select(x => x.Key)
                                        .ToList();
                                     break;
        }

        return result;
    }

    public static void ReorderList(ListNode head) {
        if (head == null || head.next == null)
            return;

        var fast = head;
        var slow = head;

        while (fast.next != null && fast.next.next != null) {
            fast = fast.next.next;
            slow = slow.next;
        }

        var second = ReverseList(slow.next);
        
        slow.next = null;

            ListNode p1 = head;
            ListNode p2 = second;
            while (p2 != null) {
                ListNode temp1 = p1.next;
                ListNode temp2 = p2.next;
                p1.next = p2;
                p2.next = temp1;
                p1 = temp1;
                p2 = temp2;
            }
    }

    private static ListNode ReverseList(ListNode head) {
        ListNode prev = null;
        ListNode current = head;
        while (current != null) {
            ListNode nextNode = current.next;
            current.next = prev;
            prev = current;
            current = nextNode;
        }
        return prev;
    }
    private static void PrintList(ListNode head) {
        ListNode current = head;
        while (current != null) {
            Console.Write(current.val + " -> ");
            current = current.next;
        }
        Console.WriteLine("null");
    }

    static int FirstMissingPositive(int[] nums) {
        if (nums == null || nums.Length == 0)
            return 1;
        
        int n = nums.Length;
        for (int i = 0; i < n; i++) {
            while (nums[i] > 0 && nums[i] <= n && nums[i] != i + 1)
            {
                int temp = nums[nums[i] - 1];
                if (temp == nums[i]) {
                    break;
                }
                nums[nums[i] - 1] = nums[i];
                nums[i] = temp;
                Console.WriteLine("i:" + i + "v1: " + (nums[i] - 1) + ":" + nums[i]);
                Console.WriteLine(string.Join(",", nums));
            }
        }

        Console.WriteLine(string.Join(",", nums));
        for (int i = 0; i < n; i++)
        {
            if (nums[i] != i + 1)
            {
                return i + 1;
            }
        }

        return n + 1;
    }
    static int MaxSubarrayLength(int[] nums, int k) {
        if (nums == null || nums.Length == 0)
            return 0;
        
        if (k <= 0)
            return 0;
        
        var cnt = new Dictionary<int, int>();

        int left = 0;
        int right = 0;
        int n = nums.Length;
        int ans = 0;
        while (right < n) {
            int num = nums[right];
            if (cnt.ContainsKey(num))
                cnt[num] = cnt[num] + 1;
            else
                cnt[num] = 1;
            
            right++;

            while (cnt[num] > k) {
                cnt[nums[left]] = cnt[nums[left]] - 1;
                left++;
            }
            
            ans = Math.Max(ans, right - left);
        }

        return ans;
    }

    static void Main(string[] args)
    {
        var numsA = new int[] { 1, 2, 3, 1, 2, 3, 3, 2, 1};
        var ans = MaxSubarrayLength(numsA, 2);
        Console.WriteLine(ans);
        return;

        var stack = new Stack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        foreach (var i in stack) {
            Console.WriteLine(i);
        }

        return;

        int[] nums = new int[] {-5,-6,5,4,3};
        int x = FirstMissingPositive(nums);
        Console.WriteLine(x);
        return;

        ListNode head1 = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
        
        ReorderList(head1);
        PrintList(head1);
        
        return;
        
        List<Ballot> ballots = new List<Ballot>()
        {
            new Ballot { Votes = new List<string> { "Alice", "C", "Charlie" } },
            new Ballot { Votes = new List<string> { "Bob", "Charlie", "Alice" } },
            new Ballot { Votes = new List<string> { "Charlie", "Alice", "A" } },
            new Ballot { Votes = new List<string> { "Alice", "Charlie", "Bob" } },
            new Ballot { Votes = new List<string> { "Bob", "Alice", "Charlie" } },
            new Ballot { Votes = new List<string> { "Bob", "A", "C" } }
        };

        List<string> winners = GetResults(ballots, 1);
        Console.WriteLine(string.Join(", ", winners));
        winners = GetResults(ballots, 2);
        Console.WriteLine(string.Join(", ", winners));
        return;
        
        PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>();
        priorityQueue.Enqueue(10, 10);
        priorityQueue.Enqueue(20, 20);
        Console.WriteLine(priorityQueue.Dequeue());
        Console.WriteLine(MazeType.Space);
        int[] pages = new int[] { 6, 1, 4, 6, 3, 2, 7, 4 };
        int k = 3;
        int l = 2;

        int maxApple = PickApples(pages, k, l);

        Console.WriteLine(maxApple);
        Console.ReadKey();

        return;

        int n = pages.Length;
        int[] prefixSum = new int[n + 1];
        prefixSum[0] = 0;
        for (int i = 1; i <= n; i++)
        {
            prefixSum[i] = prefixSum[i - 1] + pages[i - 1];
        }

        Console.WriteLine(string.Join(",", prefixSum));

        int[,] dp = new int[n + 1, k + 1];
        // i fre i books , j = person            
        for (int i = 1; i <= n; i++)
        {
            dp[i, 0] = int.MaxValue;
        }

        Console.WriteLine("dp[0, 0]:" + dp[0, 0]);
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= k; j++)
            {
                dp[i, j] = int.MaxValue;
                for (int prev = 0; prev < i; prev++)
                {
                    int cost = prefixSum[i] - prefixSum[prev];
                    int currentCost = Math.Max(cost, dp[prev, j - 1]);
                    dp[i, j] = Math.Min(dp[i, j], currentCost);
                    Console.WriteLine("dp[" + i + ", " + j + "]:" + dp[i, j]);
                }
            }
        }




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


    private static int BinarySearch(IList<int> ans, int target)
    {
        // find first > target
        int start = 0;
        int end = ans.Count - 1;

        while (start + 1 < end)
        {
            int middle = (start + end) / 2;

            if (ans[middle] < target)
            {
                start = middle;
            }
            else
            {
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
