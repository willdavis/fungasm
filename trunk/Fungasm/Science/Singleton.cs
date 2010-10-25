using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fungasm.Science
{
    /// <summary>
    /// THERE CAN BE ONLY ONE!!
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Singleton<T> where T : Singleton<T>
    {
        protected Singleton() { }

        private static T _instance;

        /// <summary>
        /// Returns true if Singleton instance is not equal to null.  Helps maintain thread saftey
        /// </summary>
        protected static bool Initialised
        {
            get
            {
                return (_instance != null);
            }
        }


        /// <summary>
        /// Returns a reference to the Singleton instance
        /// </summary>
        protected static T UniqueInstance
        {
            get
            {
                if (Initialised)
                    return SingletonFactory.getInstance;
                else
                    return null;
            }
        }

        /// <summary>
        /// Attempt to initilize Type "T" as a new Instance
        /// </summary>
        /// <param name="newInstance"></param>
        /// <exception cref="ArgumentNullException"></exception>
        protected static void Init(T newInstance)
        {
            if (newInstance == null)
                throw new ArgumentNullException();

            _instance = newInstance;
        }

        /// <summary>
        /// Internal class to safely retrieve a Singleton instance
        /// </summary>
        class SingletonFactory
        {
            static SingletonFactory() { }

            internal static readonly T getInstance = _instance;
        }
    }
}
