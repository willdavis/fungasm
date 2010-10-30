using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Threading;

using Fungasm.Science;

namespace Fungasm.Core
{
    public class InputManager : Singleton<InputManager>, ITask
    {
        #region Singleton Properties

        private InputManager() { }

        public static InputManager Instance
        {
            get
            {
                if (!Initialised)
                    Init(new InputManager());

                return UniqueInstance;
            }
        }

        #endregion


        private MouseInput _input;
        private Window _windowHandle;

        public bool Init(Window window, MouseInput input)
        {
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

            // Now use our point definition,
            Point adjustedMousePoint = new Point();
            adjustedMousePoint.X = (float)_input.MousePosition.X - ((float)_windowHandle.ActualWidth / 2);
            adjustedMousePoint.Y = ((float)_windowHandle.ActualHeight / 2) - (float)_input.MousePosition.Y;

            _windowHandle.Dispatcher.Invoke(DispatcherPriority.ApplicationIdle,
                (Action)(() => { _input.MousePosition = adjustedMousePoint; Console.WriteLine(_input.MousePosition.ToString()); }));

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
