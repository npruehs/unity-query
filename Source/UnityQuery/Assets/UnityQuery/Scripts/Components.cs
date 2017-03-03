// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameObjects.cs" company="Nick Prühs">
//   Copyright (c) Nick Prühs. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace UnityQuery
{
    using UnityEngine;

    public static class Components
    {
        #region Public Methods and Operators

        /// <summary>
        ///   Tries to get the component on the same <see cref="GameObject"/> of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">Type of the component to get.</typeparam>
        /// <param name="obj"><see cref="Component"/> on the game object to try to get the component of.</param>
        /// <param name="component">Found component, or <c>null</c> otherwise.</param>
        /// <returns><c>true</c> if a component was found, and <c>false</c> otherwise.</returns>
        public static bool TryGetComponent<T>(this Component obj, out T component)
        {
            component = obj.GetComponent<T>();
            return component != null;
        }

        #endregion
    }
}