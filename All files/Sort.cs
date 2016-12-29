using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    abstract class Sort: GraphHelper, FileManager
    {
        internal bool sorted;

        internal int numberOfItems;

        internal int[] dataItems;

        public abstract int[] sort(int[] dataItems);

        internal abstract void writeSortedData(string sortedDataFile);

        internal abstract void writeSortStats(string dataStatsFile);

        public int[] readItems(string dataFileName)
        {
            throw new NotImplementedException();
        }

        public void writeItems(string writeFileName)
        {
            throw new NotImplementedException();
        }

        public int[] readSortStats(string sortStatsDataName)
        {
            throw new NotImplementedException();
        }

        public void updateGraph(int[] graphData)
        {
            throw new NotImplementedException();
        }
    }
}
