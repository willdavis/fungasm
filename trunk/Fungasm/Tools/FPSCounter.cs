using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fungasm.Tools
{
    public class FPSCounter
    {
        int _numberOfFrames = 0;
        double _timePassed = 0;

        public double CurrentFPS { get; set; }
        public void Process(double deltaTime)
        {
            _numberOfFrames++;
            _timePassed += deltaTime;

            if (_timePassed > 1)
            {
                CurrentFPS = (double)_numberOfFrames / _timePassed;
                _timePassed = 0;
                _numberOfFrames = 0;
            }
        }
    }
}
