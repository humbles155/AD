using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AntiDebug.Self_Delete
{
    class SelfDelete
    {
        public void EraseMemory()
        {
            GC.Collect();

            GC.WaitForPendingFinalizers();
        }
    }
}
