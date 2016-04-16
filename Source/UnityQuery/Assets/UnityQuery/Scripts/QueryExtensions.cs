// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QueryExtensions.cs" company="Nick Prühs">
//   Copyright (c) Nick Prühs. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace UnityQuery
{
    using System.Collections.Generic;

    using UnityEngine;

    public static class QueryExtensions
    {
        #region Public Methods and Operators

        /// <summary>
        ///   Forces immediate execution of the query, enabling further
        ///   operations such as changing the layers or tags of all queried
        ///   objects.
        /// </summary>
        /// <param name="gameObjects">Enumeration to evaluate.</param>
        /// <returns>Query for further execution.</returns>
        public static Query<GameObject> AsQuery(this IEnumerable<GameObject> gameObjects)
        {
            return new Query<GameObject>(gameObjects);
        }

        /// <summary>
        ///   Forces immediate execution of the query, enabling further
        ///   operations such as changing the layers or tags of all queried
        ///   objects.
        /// </summary>
        /// <param name="gameObjects">Enumeration to evaluate.</param>
        /// <returns>Query for further execution.</returns>
        public static Query<GameObject> AsQuery(this List<GameObject> gameObjects)
        {
            return new Query<GameObject>(gameObjects);
        }

        #endregion
    }
}