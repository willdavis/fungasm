using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Threading;

using Fungasm.Science;

namespace Fungasm.Core
{
    /// <summary>
    /// Kernel Sanders does chicken right
    /// </summary>
    public class KernelS : Singleton<KernelS>
    {
        #region Singleton Properties

        private KernelS() { _dispatcher = Dispatcher.CurrentDispatcher; }
        public static KernelS Instance
        {
            get
            {
                if (!Initialised)
                    Init(new KernelS());

                return UniqueInstance;
            }
        }
        
        #endregion

        private Dispatcher _dispatcher;
        private Thread _gameLoop;
        private Timer _timer = new Timer();
        private List<ITask> _taskList = new List<ITask>();
        private List<ITask> _pausedTaskList = new List<ITask>();

        private void ManageTasks(double deltaTime)
        {
            //Console.WriteLine(1/deltaTime);

            //Update tasks
            for (int i = 0; i < _taskList.Count; i++)
            {
                if (!_taskList[i].CanKill)
                    _taskList[i].Update(deltaTime);
            }

            //Remove dead tasks
            for (int j = 0; j < _taskList.Count; j++)
            {
                if (_taskList[j].CanKill)
                {
                    _taskList[j].Stop();
                    _taskList.RemoveAt(j);
                }
            }
        }

        /// <summary>
        /// Begins execution of the main game thread, which will run until the UI Thread exits
        /// </summary>
        public void Execute()
        {
            _gameLoop = new Thread(new ThreadStart( () => { while (!_dispatcher.HasShutdownStarted) { ManageTasks(_timer.GetElapsedTime()); } }));
            _gameLoop.Name = "GameLoopNIGGA";
            _gameLoop.IsBackground = true;
            _gameLoop.Priority = ThreadPriority.AboveNormal;
            _gameLoop.SetApartmentState(ApartmentState.STA);
            _gameLoop.Start();
        }
        public bool AddTask(ITask task)
        {
            if (!task.Start())
                return false;

            //Find the first element in the task list whose priority is greater than the task's priority
            int index = _taskList.FindIndex(0, _taskList.Count, (ITask i) => i.Priority > task.Priority);

            //FindIndex returns -1 if nothing was found, if this is the case, simply insert the task onto the end of the task list.  Otherwise, insert the task at the specified index
            //From MSDN:    In collections of contiguous elements, such as lists, the elements that follow the insertion point move down to accommodate the new element.
            if (index == -1)
                _taskList.Add(task);
            else
                _taskList.Insert(index, task);

            return true;
        }
        public void SuspendTask(ITask task)
        {
            if (_taskList.Contains(task))
            {
                task.OnSuspend();
                _taskList.Remove(task);
                _pausedTaskList.Add(task);
            }
            else
                throw new KeyNotFoundException();
        }
        public void ResumeTask(ITask task)
        {
            if (_pausedTaskList.Contains(task))
            {
                task.OnResume();
                _pausedTaskList.Remove(task);
                _taskList.Add(task);
            }
            else
                throw new KeyNotFoundException();
        }
        public void RemoveTask(ITask task)
        {
            task.CanKill = true;
        }
        public void KillAllTasks()
        {
            foreach (ITask task in _taskList)
            {
                task.CanKill = true;
            }
        }
        public void OutputCurrentTasks()
        {
            foreach (ITask t in _taskList)
            {
                Console.WriteLine(t.Priority);
            }
        }
    }
}
