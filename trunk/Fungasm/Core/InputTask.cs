using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Threading;

using Tao.Platform.Windows;

namespace Fungasm.Core
{
    public class InputTask : ITask
    {
        private MouseInput _input;
        private Window _windowHandle;
        private SimpleOpenGlControl _openGlControl;

        public bool Init(Window window, MouseInput input, SimpleOpenGlControl openGLCtrl)
        {
            _openGlControl = openGLCtrl;
            _windowHandle = window;
            _input = input;
            return true;
        }

        #region ITask Members

        private bool _canKill = false;
        private int _priority = 25;

        public bool CanKill
        {
            get { return _canKill; }
            set { _canKill = value; }
        }
        public int Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }

        public void Update(double elapsedTime)
        {
            _windowHandle.Dispatcher.Invoke(DispatcherPriority.ApplicationIdle,
                (Action)(() => { _input.MousePosition = MouseInput.GetPosition(_windowHandle); }));

            // Adjust mosue point to OpenGL Coordinates (center of SimpleOpenGLControl is <0,0>)
            Point adjustedMousePoint = new Point();
            adjustedMousePoint.X = (float)_input.MousePosition.X - ((float)_openGlControl.Width / 2);
            adjustedMousePoint.Y = ((float)_openGlControl.Height / 2) - (float)_input.MousePosition.Y;

            _windowHandle.Dispatcher.Invoke(DispatcherPriority.ApplicationIdle,
                (Action)(() => { _input.MousePosition = adjustedMousePoint; }));
            
        }

        public bool Start()
        {
            return true;
        }

        public void OnSuspend()
        {
            throw new NotImplementedException();
        }

        public void OnResume()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
