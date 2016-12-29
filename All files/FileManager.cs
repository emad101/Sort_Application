using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WindowsFormsApplication1
{
     interface FileManager
    {
        int[] readItems(string dataFileName);

        void writeItems(string writeFileName);
    }
}