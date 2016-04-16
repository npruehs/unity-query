// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Hierarchy.cs" company="Nick Prühs">
//   Copyright (c) Nick Prühs. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace UnityQuery
{
    using System.Collections.Generic;
    using System.Linq;

    using UnityEngine;

    public static class Hierarchy
    {
        #region Public Methods and Operators

        /// <summary>
        ///   Selects all ancestors (parent, grandparent, etc.) of a game object.
        /// </summary>
        /// <param name="gameObject">Game object to select the ancestors of.</param>
        /// <returns>All ancestors of the object.</returns>
        public static IEnumerable<GameObject> GetAncestors(this GameObject gameObject)
        {
            var parent = gameObject.transform.parent;

            while (parent != null)
            {
                yield return parent.gameObject;
                parent = parent.parent;
            }
        }

        /// <summary>
        ///   Selects all ancestors (parent, grandparent, etc.) of a game object,
        ///   and the game object itself.
        /// </summary>
        /// <param name="gameObject">Game object to select the ancestors of.</param>
        /// <returns>
        ///   All ancestors of the game object,
        ///   and the game object itself.
        /// </returns>
        public static IEnumerable<GameObject> GetAncestorsAndSelf(this GameObject gameObject)
        {
            yield return gameObject;

            foreach (var ancestor in gameObject.GetAncestors())
            {
                yield return ancestor;
            }
        }

        /// <summary>
        ///   Selects all children of a game object.
        /// </summary>
        /// <param name="gameObject">Game object to select the children of.</param>
        /// <returns>All children of the game object.</returns>
        public static IEnumerable<GameObject> GetChildren(this GameObject gameObject)
        {
            return (from Transform child in gameObject.transform select child.gameObject);
        }

        /// <summary>
        ///   Selects all descendants (children, grandchildren, etc.) of a game object.
        /// </summary>
        /// <param name="gameObject">Game object to select the descendants of.</param>
        /// <returns>All descendants of the game object.</returns>
        public static IEnumerable<GameObject> GetDescendants(this GameObject gameObject)
        {
            foreach (var child in gameObject.GetChildren())
            {
                yield return child;

                // Depth-first.
                foreach (var descendant in child.GetDescendants())
                {
                    yield return descendant;
                }
            }
        }

        /// <summary>
        ///   Selects all descendants (children, grandchildren, etc.) of a
        ///   game object, and the game object itself.
        /// </summary>
        /// <param name="gameObject">Game object to select the descendants of.</param>
        /// <returns>
        ///   All descendants of the game object,
        ///   and the game object itself.
        /// </returns>
        public static IEnumerable<GameObject> GetDescendantsAndSelf(this GameObject gameObject)
        {
            yield return gameObject;

            foreach (var descendant in gameObject.GetDescendants())
            {
                yield return descendant;
            }
        }

        /// <summary>
        ///   Gets the hierarchy root of the game object.
        /// </summary>
        /// <param name="gameObject">Game object to get the root of.</param>
        /// <returns>Root of the specified game object.</returns>
        public static GameObject GetRoot(this GameObject gameObject)
        {
            var root = gameObject.transform;

            while (root.parent != null)
            {
                root = root.parent;
            }

            return root.gameObject;
        }

        /// <summary>
        ///   Indicates whether the a game object is an ancestor of another one.
        /// </summary>
        /// <param name="gameObject">Possible ancestor.</param>
        /// <param name="descendant">Possible descendant.</param>
        /// <returns>
        ///   <c>true</c>, if the game object is an ancestor of the other one, and
        ///   <c>false</c> otherwise.
        /// </returns>
        public static bool IsAncestorOf(this GameObject gameObject, GameObject descendant)
        {
            return gameObject.GetDescendants().Contains(descendant);
        }

        /// <summary>
        ///   Indicates whether the a game object is a descendant of another one.
        /// </summary>
        /// <param name="gameObject">Possible descendant.</param>
        /// <param name="ancestor">Possible ancestor.</param>
        /// <returns>
        ///   <c>true</c>, if the game object is a descendant of the other one, and
        ///   <c>false</c> otherwise.
        /// </returns>
        public static bool IsDescendantOf(this GameObject gameObject, GameObject ancestor)
        {
            return gameObject.GetAncestors().Contains(ancestor);
        }

        /// <summary>
        ///   Filters a sequence of game objects by layer.
        /// </summary>
        /// <param name="gameObjects">Game objects to filter.</param>
        /// <param name="layer">Layer to get the game objects of.</param>
        /// <returns>Game objects on the specified layer.</returns>
        public static IEnumerable<GameObject> OnLayer(this IEnumerable<GameObject> gameObjects, int layer)
        {
            return gameObjects.Where(gameObject => Equals(gameObject.layer, layer));
        }

        /// <summary>
        ///   Filters a sequence of game objects by layer.
        /// </summary>
        /// <param name="gameObjects">Game objects to filter.</param>
        /// <param name="layerName">Layer to get the game objects of.</param>
        /// <returns>Game objects on the specified layer.</returns>
        public static IEnumerable<GameObject> OnLayer(this IEnumerable<GameObject> gameObjects, string layerName)
        {
            var layer = LayerMask.NameToLayer(layerName);
            return gameObjects.Where(gameObject => Equals(gameObject.layer, layer));
        }

        /// <summary>
        ///   Filters a sequence of game objects by tag.
        /// </summary>
        /// <param name="gameObjects">Game objects to filter.</param>
        /// <param name="tag">Tag to get the game objects of.</param>
        /// <returns>Game objects with the specified tag.</returns>
        public static IEnumerable<GameObject> WithTag(this IEnumerable<GameObject> gameObjects, string tag)
        {
            return gameObjects.Where(gameObject => Equals(gameObject.tag, tag));
        }

        #endregion
    }
}