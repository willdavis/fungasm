using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Threading;

using Tao.Platform.Windows;
using Tao.OpenGl;

namespace Fungasm.Core
{
    public class VideoTask : ITask
    {
        private Dispatcher _dispatcher;
        private bool _canKill = false;
        private Int32 _priority = 1000;
        private SimpleOpenGlControl _openGLControl;

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

        public SimpleOpenGlControl OpenGLControl
        {
            get { return _openGLControl; }
            set { _openGLControl = value; }
        }

        public bool Init(SimpleOpenGlControl control)
        {
            if (control == null)
                return false;

            _dispatcher = Dispatcher.CurrentDispatcher;
            _openGLControl = control;
            return true;
        }

        #region ITask Members

        public bool Start()
        {
            try
            {
                _openGLControl.InitializeContexts();
                Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("{0}\nUnable to Initialise OpenGL Context\n{1}\n{2}", e.TargetSite, e.Message, e.StackTrace));
                return false;
            }
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void Update(double deltaTime)
        {
            _dispatcher.Invoke(DispatcherPriority.ApplicationIdle, (Action)(() =>
            {
                //Update and render the current game state
                StateManager.Instance.Update(deltaTime);
                StateManager.Instance.Render();
                _openGLControl.Refresh();
            }));
        }

        public void OnSuspend()
        {
            throw new NotImplementedException();
        }

        public void OnResume()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
