using System;
using System.Reflection;

namespace drules.dates.library.util
{
    /// <summary>
    /// Generic thread safe singleton class
    /// </summary>
    /// <typeparam name="T">Class to create</typeparam>
    public class Singleton<T> where T : class
    {
        public static T Instance
        {
            get { return (SingletonCreator.Instance); }
        }

        /// <summary>
        /// Private class to create a thread safe single instance of the class T
        /// </summary>
        private class SingletonCreator
        {
            static SingletonCreator() { }

            internal static readonly T Instance = typeof(T).GetConstructor(
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                Type.DefaultBinder,
                Type.EmptyTypes,
                null).Invoke(null) as T;
        }
    }
}