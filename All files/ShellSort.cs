using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
      /*
      * What does shell sort do:
      * basicely shell sort trys to sort large numbers that are far apart
      * if the sort found larger number that are far than it re position it so it can be in the right order
      * it keep doing this to all nmber that are far until all of the number are sorted
      *if there are no large value than it goes through the next number untile it finds one
      */
namespace WindowsFormsApplication1
{
    
    //code taken from Wikipedia pesucode

    class ShellSort : Sort
    {
        /* 
   *This method have three parameter the array and the minum value of the number of data and the maximun value of the num of data
   * this function also returns the value of the stop watch that took the sort method to do
   */
        internal static Stopwatch Shell(int[] array, int left, int right)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Reset();
            stopwatch.Start();
            int i=left, j=right, increment;
          int temp;
            
            increment = array.Length / 2; // it takes the length of the array and divids it to half 
            while (increment > 0)
            {
                for (i = 0; i < array.Length; i++)
                {
                    j = i;
                    temp = array[i];
                    //this is where the number that the array compare go through all of the numbers of the array to find the larget number to put it in order
                    while ((j >= increment) && (array[j - increment].CompareTo(temp) > 0))
                    {
                        array[j] = array[j - increment];
                        j = j - increment;
                       // System.Diagnostics.Debug.Write(array[j]);
                    }
                    array[j] = temp;
                   
                }
                if (increment == 2)
                    increment = 1;
                else
                    increment = increment * 5 / 11;

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
