using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Fungasm.Science;

namespace Fungasm.Core
{
    public class ErrorManager : Singleton<ErrorManager>, IDisposable
    {
        private StreamWriter _appLogWriter;
        private StreamWriter _clientLogWriter;
        private StreamWriter _serverLogWriter;
        private List<String> _logStrings = new List<string>();

        #region Singleton Properties

        //private constructor required for Singleton design pattern
        private ErrorManager() { }

        /// <summary>
        /// Returns a reference to the unique Instance instance using lazy instantiation
        /// </summary>
        public static ErrorManager Instance
        {
            get
            {
                if (!Initialised)
                    Init(new ErrorManager());

                return UniqueInstance;
            }
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Close all Streamwriters and dispose Singleton reference
        /// </summary>
        void IDisposable.Dispose()
        {
            _appLogWriter.Close();
            _clientLogWriter.Close();
            _serverLogWriter.Close();
        }

        #endregion

        /// <summary>
        /// Load error strings into the private logStrings List, Returns true if successfull
        /// </summary>
        /// <returns></returns>
        protected bool LoadStrings()
        {
            //TODO: Implement this shit!!
            return true;
        }

        /// <summary>
        /// Initialise the FileStream's making sure not to cross them
        /// </summary>
        /// <returns></returns>
        public bool Init()
        {
            try
            {
                FileStream appLogStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "appLog.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
                FileStream clientLogStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "clientLog.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
                FileStream serverLogStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "serverLog.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);

                _appLogWriter = new StreamWriter(appLogStream);
                _clientLogWriter = new StreamWriter(clientLogStream);
                _serverLogWriter = new StreamWriter(serverLogStream);

                if (!LoadStrings())
                    return false;

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("Error occured in {0}\n{1}\n{2}\n", e.Source, e.Message, e.StackTrace));
                return false;
            }
        }

        /// <summary>
        /// Writes String parameter to the specified error log StreamWriter
        /// </summary>
        /// <param name="target"></param>
        /// <param name="msgID"></param>
        /// <exception cref="NullReferenceException">Thrown if _logStrings == null</exception>
        public void Write(ErrorLogType target, String msg)
        {
            switch (target)
            {
                case ErrorLogType.APP:
                    _appLogWriter.WriteLine(msg);
                    break;
                case ErrorLogType.CLIENT:
                    _clientLogWriter.WriteLine(msg);
                    break;
                case ErrorLogType.SERVER:
                    _serverLogWriter.WriteLine(msg);
                    break;
                case ErrorLogType.USER:
                    Console.WriteLine(msg);
                    break;
            }
        }

        /// <summary>
        /// Writes String parameter to the specified error log StreamWriter 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="msgID"></param>
        /// <exception cref="NullReferenceException">Thrown if _logStrings == null</exception>
        public void Write(ErrorLogType target, Int32 msgID)
        {
            if (_logStrings == null)
                throw new NullReferenceException();

            switch (target)
            {
                case ErrorLogType.APP:
                    _appLogWriter.WriteLine(_logStrings[msgID]);
                    break;
                case ErrorLogType.CLIENT:
                    _clientLogWriter.WriteLine(_logStrings[msgID]);
                    break;
                case ErrorLogType.SERVER:
                    _serverLogWriter.WriteLine(_logStrings[msgID]);
                    break;
                case ErrorLogType.USER:
                    Console.WriteLine(_logStrings[msgID]);
                    break;
            }
        }
    }

    /// <summary>
    /// Happy poopy time enumeration of the different log types ^_^
    /// </summary>
    public enum ErrorLogType
    {
        APP,
        CLIENT,
        SERVER,
        USER
    }
}
