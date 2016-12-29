using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
namespace WindowsFormsApplication1
{
    class Quiksort: Sort
    {
        /* what does the quick sort do
      * Quick sort pick on number usally it is at the middle of the unsorted methods
      * it then reorder the arrays so that all the number that with any value
        less than the number the quick sort picked come before that number
      * while all the numbers with value greater than the number it picked go after it
      *any similer value of the number that the quick sort picked go either way
      * repeat the same steps until all of the values is sorted 
      * put the the number that the quicksort picked to where it belongs
      */
        // took the code from http://www.algolist.net/Algorithms/Sorting/Quicksort
        /*
      * 
      *This method have three parameter the array and the minum value of the number of data and the maximun value of the num of data
      * this function also returns the value of the stop watch that took the sort method to do
      */
        internal static Stopwatch quickSort(int[] arr, int left, int right)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Reset();
            stopwatch.Start();
            int i = left, // the minum value of the numdata
                j = right; // the maximum number of numdata
            int tmp;  // a teprerary value
            int pivot = arr[(left + right) / 2]; // this is where the method takes a number and apply all of the number to after or before it
            
            /* partition */
            //repeat steps untile every thing is sorted
            while (i <= j)
            {
                // while the number is less than the pivot go before that number
                while (arr[i] < pivot)
                {
                    i++;
                }
                // while the number is greater than the pivot go after it
                while (arr[j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    tmp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tmp;
                    i++;
                    j--;
                }
            };

            /* recursion  */
            if (left < j)
                quickSort(arr, left, j);
            if (i < right)
                quickSort(arr, i, right);
            stopwatch.Stop();
            return stopwatch;
        }

        public override int[] sort(int[] dataItems)
        {
            throw new NotImplementedException();
        }

        internal override void writeSortedData(string sortedDataFile)
        {
            throw new NotImplementedException();
        }

        internal override void writeSortStats(string dataStatsFile)
        {
            throw new NotImplementedException();
        }
    }
}
