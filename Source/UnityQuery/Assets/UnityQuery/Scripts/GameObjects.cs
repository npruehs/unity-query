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
        ///   Instantiates a new game object and parents it to this one.
        ///   Resets position, rotation and scale and inherits the layer.
        /// </summary>
        /// <param name="parent">Game object to add the child to.</param>
        /// <returns>New child.</returns>
        public static GameObject AddChild(this GameObject parent)
        {
            return parent.AddChild("New Game Object");
        }

        /// <summary>
        ///   Instantiates a new game object and parents it to this one.
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
        ///   Instantiates a prefab and parents it to this one.
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
            transform.Reset();
            go.layer = parent.layer;
            return go;
        }

        /// <summary>
        ///   Destroys all children of a object.
        /// </summary>
        /// <param name="gameObject">Game object to destroy all children of.</param>
        public static void DestroyChildren(this GameObject gameObject)
        {
            foreach (var child in gameObject.GetChildren())
            {
                // Hide immediately.
                child.SetActive(false);

                if (Application.isEditor && !Application.isPlaying)
                {
                    Object.DestroyImmediate(child);
                }
                else
                {
                    Object.Destroy(child);
                }
            }
        }

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
        ///   Returns the full path of a game object, i.e. the names of all
        ///   ancestors and the game object itself.
        /// </summary>
        /// <param name="gameObject">Game object to get the path of.</param>
        /// <returns>Full path of the game object.</returns>
        public static string GetPath(this GameObject gameObject)
        {
            return
                gameObject.GetAncestorsAndSelf()
                    .Reverse()
                    .Aggregate(string.Empty, (path, go) => path + "/" + go.name)
                    .Substring(1);
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
        ///   Resets the local position, rotation and scale of a transform.
        /// </summary>
        /// <param name="transform">Transform to reset.</param>
        public static void Reset(this Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
        }

        /// <summary>
        ///   Sets the layer of the game object.
        /// </summary>
        /// <param name="gameObject">Game object to set the layer of.</param>
        /// <param name="layerName">Name of the new layer.</param>
        public static void SetLayer(this GameObject gameObject, string layerName)
        {
            var layer = LayerMask.NameToLayer(layerName);
            gameObject.layer = layer;
        }

        /// <summary>
        ///   Sets the layer of the game object and all of its descendants.
        /// </summary>
        /// <param name="gameObject">Game object to set the layers of.</param>
        /// <param name="layerName">Name of the new layer.</param>
        public static void SetLayers(this GameObject gameObject, string layerName)
        {
            var layer = LayerMask.NameToLayer(layerName);
            gameObject.SetLayers(layer);
        }

        /// <summary>
        ///   Sets the layer of the game object and all of its descendants.
        /// </summary>
        /// <param name="gameObject">Game object to set the layers of.</param>
        /// <param name="layer">New layer.</param>
        public static void SetLayers(this GameObject gameObject, int layer)
        {
            foreach (var o in gameObject.GetDescendantsAndSelf())
            {
                o.layer = layer;
            }
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