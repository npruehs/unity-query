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

        public static Vector2 WithX(this Vector2 v, float newX)
        {
            return new Vector2(newX, v.y);
        }

        public static Vector3 WithX(this Vector3 v, float newX)
        {
            return new Vector3(newX, v.y, v.z);
        }

        public static Vector2 WithY(this Vector2 v, float newY)
        {
            return new Vector2(v.x, newY);
        }

        public static Vector3 WithY(this Vector3 v, float newY)
        {
            return new Vector3(v.x, newY, v.z);
        }

        public static Vector3 WithZ(this Vector3 v, float newZ)
        {
            return new Vector3(v.x, v.y, newZ);
        }

        public static Vector2 XY(this Vector3 v)
        {
            return new Vector2(v.x, v.y);
        }

        public static Vector2 XZ(this Vector3 v)
        {
            return new Vector2(v.x, v.z);
        }

        public static Vector2 YZ(this Vector3 v)
        {
            return new Vector2(v.y, v.z);
        }

        #endregion
    }
}