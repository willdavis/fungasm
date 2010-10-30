using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fungasm.Core
{
    public interface ITask
    {
        bool CanKill { get; set; }
        Int32 Priority { get; set; }

        void Update(double elapsedTime);
        bool Start();
        void OnSuspend();
        void OnResume();
        void Stop();
    }
}
