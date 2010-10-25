using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.InteropServices;

namespace Fungasm.Core
{
    public class Timer
    {
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport("Kernel32")]
        public static extern bool QueryPerformanceFrequency(ref long PerformanceFrequency);

        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport("Kernel32")]
        public static extern bool QueryPerformanceCounter(ref long PerformanceCount);

        long _ticksPerSecond = 0;
        long _previousElapsedTime = 0;

        public Timer()
        {
            QueryPerformanceFrequency(ref _ticksPerSecond);
            GetElapsedTime();   //Discard the first result, which is garbage
        }

        public double GetElapsedTime()
        {
            long time = 0;
            QueryPerformanceCounter(ref time);

            double deltaTime = (double)(time - _previousElapsedTime) / (double)_ticksPerSecond;
            _previousElapsedTime = time;
            return deltaTime;
        }
    }
}
