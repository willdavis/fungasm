using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Fungasm.Science;

namespace Fungasm.Core
{
    public class StateManager : Singleton<StateManager>, ITask
    {
        private IRenderable _currentState = null;
        private Dictionary<String, IRenderable> _stateMap = new Dictionary<string, IRenderable>();

        private bool _canKill = false;
        private int _priority = 10;

        /// <summary>
        /// Checks if the given stateID is present
        /// </summary>
        /// <param name="stateID"></param>
        /// <returns></returns>
        public bool Exists(String stateID)
        {
            return _stateMap.ContainsKey(stateID);
        }

        public void Render()
        {
            if (_currentState == null)
                return;

            _currentState.Render();
        }

        public void AddState(String stateID, IRenderable state)
        {
            if (Exists(stateID))
                throw new System.ApplicationException(string.Format("{0} is already the current state", stateID));

            _stateMap.Add(stateID, state);
        }

        public void ChangeState(String stateID)
        {
            if (Exists(stateID))
                _currentState = _stateMap[stateID];
            else
                throw new KeyNotFoundException();
        }

        #region ITask Members

        public void Update(double deltaTime)
        {
            if (_currentState == null)
                throw new NullReferenceException();

            _currentState.Update(deltaTime);
        }

        public bool Start()
        {
            Console.WriteLine("Starting up the State Manager");

            //ADD SHIT HERE :)
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

        public bool CanKill
        {
            get
            {
                return _canKill;
            }
            set
            {
                _canKill = value;
            }
        }

        public int Priority
        {
            get
            {
                return _priority;
            }
            set
            {
                _priority = value;
            }
        }

        #endregion

        #region Singleton Properties
        private StateManager() { }

        public static StateManager Instance
        {
            get
            {
                if (!Initialised)
                    Init(new StateManager());

                return UniqueInstance;
            }
        }
        #endregion
    }
}
