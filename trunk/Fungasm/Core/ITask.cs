using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fungasm.Core
{
    public interface ITask
    {
        bool Start();
        void OnSuspend();
        void Update(double elapsedTime);
        void OnResume();
        void Stop();

        bool CanKill { get; set; }
        Int32 Priority { get; set; }
    }
}
