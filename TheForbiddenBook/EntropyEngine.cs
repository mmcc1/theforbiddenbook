using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheForbiddenBook
{
    public delegate void RaiseHandler(int i);

    public class EntropyEngine
    {
        public event RaiseHandler RaiseSeq;
        Thread[] threads;

        public void StartEngine()
        {
            threads = new Thread[255];

            for(int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(new ParameterizedThreadStart(RaiseEvent));
                threads[i].Start((object)i);
            }
        }
        private void RaiseEvent(object threadNum)
        {
            int i = (int) threadNum;
            
            while (true)
            {
                Thread.Sleep(1);
                Application.DoEvents();
                RaiseSeq(i);
            }
        }

        public void KillThreads()
        {
            for (int i = 0; i < threads.Length; i++)
                threads[i].Abort();
        }
    }
}
