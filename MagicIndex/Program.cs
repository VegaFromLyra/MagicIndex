using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given a sorted array of ints, find the value such that a[i] = i
// There is only one such value, if any. This is know as magic index
namespace MagicIndex
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] testcase1 = {-5, -3, 1, 2, 4 };

            Console.WriteLine("Magic Index for Test case 1 is {0}", FindMagicIndex1(testcase1));

            int[] testcase2 = { -5, -3, 1, 2, 3, 5, 5 };

            Console.WriteLine("Magic Index for Test case 2 is {0}", FindMagicIndex1(testcase2));
        }

        // Solution 1 - If the array has distinct values
        static int FindMagicIndex1(int[] arr)
        {
            return FindMagicIndex1(arr, 0, arr.Length - 1);
        }

        static int FindMagicIndex1(int[] arr, int start, int end)
        {
            if (end < start)
            {
                return -1;
            }

            int mid = (start + end) / 2;

            int midValue = arr[mid];

            if (midValue == mid)
            {
                return mid;
            }
            else if (midValue < mid)
            {
                return FindMagicIndex1(arr, mid + 1, end);
            }
            else
            {
                return FindMagicIndex1(arr, start, mid - 1);
            }
        }

        // Solution 2 - If the array has repeated values
        int FindMagicIndex2(int[] arr)
        {
            return FindMagicIndex2(arr, 0, arr.Length - 1);
        }

        int FindMagicIndex2(int[] arr, int start, int end)
        {
            if (end < start)
            {
                return -1;
            }

            int mid = (start + end) / 2;

            int midValue = arr[mid];

            if (midValue == mid)
            {
                return mid;
            }

            // Need to check both left and right parts
            int leftResult = FindMagicIndex2(arr, start, mid - 1);

            if (leftResult != -1)
            {
                return leftResult;
            }

            return FindMagicIndex2(arr, mid + 1, end);
        }


    }
}
