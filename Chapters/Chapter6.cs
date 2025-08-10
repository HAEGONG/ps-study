using System.Text;

namespace ps_study.Chapters;

public class SelectionSort : BaseClass
{
    protected override string SetTitle()
    {
        return "선택 정렬";
    }

    protected override void Example()
    {
        int[] arr = {7, 5, 9, 0, 3, 1, 6, 2, 4, 8};

        for (int i = 0; i < arr.Length; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[minIndex] > arr[j])
                    minIndex = j;
            }
            (arr[i], arr[minIndex]) = (arr[minIndex], arr[i]);
        }
        
        Console.WriteLine(string.Join(" ", arr));
    }
}

public class InsertionSort : BaseClass
{
    protected override string SetTitle()
    {
        return "삽입 정렬";
    }

    protected override void Example()
    {
        int[] arr = {7, 5, 9, 0, 3, 1, 6, 2, 4, 8};

        for (int i = 1; i < arr.Length; i++)
        {
            for (int j = i; j > 0; j--)
            {
                if (arr[j] < arr[j - 1])
                {
                    (arr[j], arr[j - 1]) = (arr[j - 1], arr[j]);
                }
                else
                {
                    break;
                }
            }
        }
        
        Console.WriteLine(string.Join(" ", arr));
    }
}

public class QuickSort : BaseClass
{
    protected override string SetTitle()
    {
        return "퀵 정렬";
    }

    protected override void Example()
    {
        int[] arr = {7, 5, 9, 0, 3, 1, 6, 2, 4, 8};
        
        quickSort(arr, 0, arr.Length - 1);
        Console.WriteLine(string.Join(" ", arr));
    }

    void quickSort(int[] arr, int start, int end)
    {
        if (start >= end)
            return;

        int pivot = start;
        int left = start + 1;
        int right = end;

        while (left <= right)
        {
            while (left <= end && arr[left] <= arr[pivot]) left++;
            while (right > start && arr[right] >= arr[pivot]) right--;

            if (left > right)
            {
                (arr[pivot], arr[right]) = (arr[right], arr[pivot]);
            }
            else
            {
                (arr[left], arr[right]) = (arr[right], arr[left]);
            }
        }
        quickSort(arr, start, right - 1);
        quickSort(arr, right + 1, end);
    }
}

public class CountingSort : BaseClass
{
    protected override string SetTitle()
    {
        return "계수 정렬";
    }

    protected override void Example()
    {
        int[] array = { 7, 5, 9, 0, 3, 1, 6, 2, 9, 1, 4, 8, 0, 5, 2 };
        int max = array.Max();
        int[] count = new int[max + 1];

        foreach (int i in array)
        {
            count[i]++;
        }

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < count.Length; i++)
        {
            for (int j = 0; j < count[i]; j++)
            {
                sb.Append(i);
            }
        }
        
        Console.WriteLine(sb.ToString());
    }
}