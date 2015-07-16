// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Log.cs" company="Nick Prühs">
//   Copyright (c) Nick Prühs. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace UnityQuery
{
    using UnityEngine;

    public static class Log
    {
        #region Public Methods and Operators

        public static void Error(Object context, string s)
        {
            Debug.LogError(s.ToLogString(context), context);
        }

        public static void Error(Object context, string s, params object[] args)
        {
            Debug.LogErrorFormat(context, s.ToLogString(context), args);
        }

        public static void Info(Object context, string s)
        {
            Debug.Log(s.ToLogString(context), context);
        }

        public static void Info(Object context, string s, params object[] args)
        {
            Debug.LogFormat(context, s.ToLogString(context), args);
        }

        public static void Warn(Object context, string s)
        {
            Debug.LogWarning(s.ToLogString(context), context);
        }

        public static void Warn(Object context, string s, params object[] args)
        {
            Debug.LogWarningFormat(context, s.ToLogString(context), args);
        }

        public static string WithFrame(this string s)
        {
            return string.Format("[{0:00000}] {1}", Time.frameCount, s);
        }

        public static string WithObjectName(this string s, Object o)
        {
            return string.Format("[{0}] {1}", o.name, s);
        }

        public static string WithTimestamp(this string s)
        {
            return string.Format("[{0:000.000}] {1}", Time.realtimeSinceStartup, s);
        }

        #endregion

        #region Methods

        private static string ToLogString(this string s, Object context)
        {
            return s.WithObjectName(context).WithTimestamp();
        }

        #endregion
    }
}