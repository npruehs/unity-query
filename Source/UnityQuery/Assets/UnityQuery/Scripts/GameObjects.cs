// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameObjects.cs" company="Nick Prühs">
//   Copyright (c) Nick Prühs. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace UnityQuery
{
    using System.Collections.Generic;
    using System.Linq;

    using UnityEngine;

    public static class GameObjects
    {
        #region Public Methods and Operators

        /// <summary>
        ///   Instantiates a new game object and parents it to the specified one.
        ///   Resets position, rotation and scale and inherits the layer.
        /// </summary>
        /// <param name="parent">Game object to add the child to.</param>
        /// <returns>New child.</returns>
        public static GameObject AddChild(this GameObject parent)
        {
            return parent.AddChild("GameObject");
        }

        /// <summary>
        ///   Instantiates a new game object and parents it to the specified one.
        ///   Resets position, rotation and scale and inherits the layer.
        /// </summary>
        /// <param name="parent">Game object to add the child to.</param>
        /// <param name="name">Name of the child to add.</param>
        /// <returns>New child.</returns>
        public static GameObject AddChild(this GameObject parent, string name)
        {
            var go = AddChild(parent, (GameObject)null);
            go.name = name;
            return go;
        }

        /// <summary>
        ///   Instantiates a prefab and parents it to the specified one.
        ///   Resets position, rotation and scale and inherits the layer.
        /// </summary>
        /// <param name="parent">Game object to add the child to.</param>
        /// <param name="prefab">Prefab to instantiate.</param>
        /// <returns>New prefab instance.</returns>
        public static GameObject AddChild(this GameObject parent, GameObject prefab)
        {
            var go = prefab != null ? Object.Instantiate(prefab) : new GameObject();
            if (go == null || parent == null)
            {
                return go;
            }

            var transform = go.transform;
            transform.parent = parent.transform;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
            go.layer = parent.layer;
            return go;
        }

        /// <summary>
        ///   Selects all ancestors (parent, grandparent, etc.) of the
        ///   specified game object.
        /// </summary>
        /// <param name="gameObject">Game object to select the ancestors of.</param>
        /// <returns>All ancestors of the specified game object.</returns>
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
        ///   Selects all ancestors (parent, grandparent, etc.) of the
        ///   specified game object, and the game object itself.
        /// </summary>
        /// <param name="gameObject">Game object to select the ancestors of.</param>
        /// <returns>
        ///   All ancestors of the specified game object,
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
        ///   Selects all children of the specified game object.
        /// </summary>
        /// <param name="gameObject">Game object to select the children of.</param>
        /// <returns>All children of the specified game object.</returns>
        public static IEnumerable<GameObject> GetChildren(this GameObject gameObject)
        {
            return (from Transform child in gameObject.transform select child.gameObject);
        }

        /// <summary>
        ///   Selects all descendants (children, grandchildren, etc.) of the
        ///   specified game object.
        /// </summary>
        /// <param name="gameObject">Game object to select the descendants of.</param>
        /// <returns>All descendants of the specified game object.</returns>
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
        ///   Selects all descendants (children, grandchildren, etc.) of the
        ///   specified game object, and the game object itself.
        /// </summary>
        /// <param name="gameObject">Game object to select the descendants of.</param>
        /// <returns>
        ///   All descendants of the specified game object,
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

        #endregion
    }
}