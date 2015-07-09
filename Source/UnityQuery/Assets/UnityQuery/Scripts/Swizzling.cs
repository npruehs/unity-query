// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Swizzling.cs" company="Nick Prühs">
//   Copyright (c) Nick Prühs. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace UnityQuery
{
    using UnityEngine;

    public static class Swizzling
    {
        #region Public Methods and Operators

        public static Vector2 XY(this Vector3 v)
        {
            return new Vector2(v.x, v.y);
        }

        public static Vector3 XY(this Vector2 v)
        {
            return new Vector3(v.x, v.y, 0.0f);
        }

        public static Vector2 XZ(this Vector3 v)
        {
            return new Vector2(v.x, v.z);
        }

        public static Vector3 XZ(this Vector2 v)
        {
            return new Vector3(v.x, 0.0f, v.y);
        }

        public static Vector2 YZ(this Vector3 v)
        {
            return new Vector2(v.y, v.z);
        }

        public static Vector3 YZ(this Vector2 v)
        {
            return new Vector3(0.0f, v.x, v.y);
        }

        #endregion
    }
}