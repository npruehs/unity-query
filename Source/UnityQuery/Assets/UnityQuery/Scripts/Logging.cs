// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Logging.cs" company="Nick Prühs">
//   Copyright (c) Nick Prühs. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace UnityQuery
{
    using UnityEngine;

    public static class Logging
    {
        #region Public Methods and Operators

        public static string WithTimestamp(this string s)
        {
            return string.Format("[{0:000.000}] {1}", Time.realtimeSinceStartup, s);
        }

        #endregion
    }
}