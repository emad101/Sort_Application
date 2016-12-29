using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
namespace WindowsFormsApplication1
{
    /* What does gnome sort do:
      *Gone sort basicley put the numbers in order by comparing the number it is in and the number before it
      * if the number it compares are in order, it moves to the next item. It also can stop if the end of the number is
        reached
      * while if they are out of order, swap the numbers and then move to the prevoius number
      * if there is no preivius number go to the next number 
      * repeat this with for loop until all of the number are sorted
      */

    class Gnome_Sort : Sort
    {
        //   code inspired from https://en.wikibooks.org/wiki/Algorithm_Implementation/Sorting/Gnome_sort#C.23
         /* 
      *This method have three parameter the array and the minum value of the number of data and the maximun value of the num of data
      * this function also returns the value of the stop watch that took the sort method to do
      */
        internal static Stopwatch gnomeSort(int[] array, int left, int right)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Reset();
            stopwatch.Start();
            
            int i = right;
            int temp_value = left;
            for ( i = 1, i= temp_value; i < array.Length;)
            {
                // in this the sort compare the teo number the number before the item and the number it is in 
                // if it is less than add one to the number of arrays
                if (array[i - 1] <= array[i])
                    i += 1;
                // if it is not less than that number then just go swap and go through the rest of the array
                else
                {
                    temp_value = array[i - 1];
                    array[i - 1] = array[i];
                    array[i] = temp_value;
                    i -= 1;
                    if (i == 0)
                        i = 1;
                }
            }
  
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
