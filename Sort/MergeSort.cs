public class SolutionMergeSort
{
    public int[] SortArray(int[] nums)
    {
        if (nums == null || nums.Length == 0)
            return nums;

        int[] temp = new int[nums.Length];
        MergeSort(nums, 0, nums.Length - 1, temp);
        return nums;
    }

    private void MergeSort(int[] nums, int start, int end, int[] temp)
    {
        if (start >= end)
            return;

        MergeSort(nums, start, (start + end) / 2, temp);
        MergeSort(nums, (start + end) / 2 + 1, end, temp);
        Merge(nums, start, end, temp);
    }

    private void Merge(int[] nums, int start, int end, int[] temp)
    {
        int middle = (start + end) / 2;
        int leftIndex = start;
        int rightIndex = middle + 1;
        int index = leftIndex;

        while (leftIndex <= middle && rightIndex <= end)
        {
            if (nums[leftIndex] < nums[rightIndex])
            {
                temp[index++] = nums[leftIndex++];
            }
            else
            {
                temp[index++] = nums[rightIndex++];
            }
        }

        while (leftIndex <= middle)
        {
            temp[index++] = nums[leftIndex++];
        }

        while (rightIndex <= end)
        {
            temp[index++] = nums[rightIndex++];
        }

        for (int i = start; i <= end; i++)
        {
            nums[i] = temp[i];
        }
    }
}