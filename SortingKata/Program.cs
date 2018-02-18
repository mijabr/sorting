using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingKata
{
    public class Program
    {
        public static int BubbleSort(int[] arr, bool ascending = true)
        {
            int numberOfComparisons = 0;
            for (int j = 0; j < arr.Length - 1; j++)
            {
                bool swapped = false;
                for (int i = 0; i < (arr.Length - j -1); i++)
                {
                    bool swap = ascending ? (arr[i] > arr[i + 1]) : arr[i] < arr[i + 1];
                    if (swap)
                    {
                        var tmp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = tmp;
                        swapped = true;
                    }

                    numberOfComparisons++;
                }

                if (!swapped)
                {
                    break;
                }
            }

            return numberOfComparisons;
        }


        static void Main(string[] args)
        {
        }

        public static int InsertionSort(int[] arr, bool ascending = true)
        {
            int numberOfComparisons = 0;
            if (arr.Length <= 1)
                return 0;

            for (int i = 1; i < arr.Length; i++)
            {
                int current = arr[i];

                for (int j = i; j >= 0; j--)
                {
                    bool noInsert =  ascending ? (j > 0 && current < arr[j - 1]) : (j > 0 && current > arr[j - 1]);
                    if (noInsert)
                    {
                        arr[j] = arr[j - 1];
                    }
                    else
                    {
                        arr[j] = current;
                        break;
                    }

                    numberOfComparisons++;
                }
            }

            return numberOfComparisons;
        }

        //public static void MergeSort(int[] arr)
        //{
        //    var arrays = new object[2];

        //    Array.Copy(arr, )

        //    //throw new NotImplementedException();
        //}

        public static void Merge (int[] arr, int low, int mid, int high)
        {
            int[] intermediate = new int[high-low+1];
            
            int start1 = low;
            int start2 = mid + 1;
            int index = 0;
            
            while (start1 <= mid || start2 <= high)
            {
                if (start1 > mid || (start2 <= high && arr[start1] > arr[start2]))
                {
                    intermediate[index] = arr[start2];
                    start2++;
                }
                else
                {
                    intermediate[index] = arr[start1];
                    start1++;
                }
                index++;
            }

            intermediate.CopyTo(arr, low);
        }

        public static void MergeSort(int[] arrMergeTen)
        {
            MergeSortRecurse(arrMergeTen, 0, arrMergeTen.Length-1);
        }

        public static void MergeSortRecurse(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int mid = (low + high) / 2;
                MergeSortRecurse(arr, low, mid);
                MergeSortRecurse(arr, mid + 1,high);
                Merge(arr, low, mid, high);
            }
        }
    }
}
