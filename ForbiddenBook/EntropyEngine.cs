using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForbiddenBook
{
    public delegate void RaiseHandler(int i);

    public class EntropyEngine
    {
        public event RaiseHandler RaiseSeq;
        Thread[] threads;
        bool shouldExit;

        public void StartEngine()
        {
            threads = new Thread[255];

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(new ParameterizedThreadStart(RaiseEvent));
                threads[i].Start((object)i);
            }
        }
        private void RaiseEvent(object threadNum)
        {
            int i = (int)threadNum;

            while (!shouldExit)
            {
                Thread.Sleep(1);
                Application.DoEvents();
                RaiseSeq(i);
            }
        }

        public void KillThreads()
        {
            shouldExit = true;
        }
    }
}
