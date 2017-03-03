// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameObjects.cs" company="Nick Prühs">
//   Copyright (c) Nick Prühs. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace UnityQuery
{
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
            transform.SetParent(parent.transform);
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
        ///   Gets the component of type <typeparamref name="T" /> if the game object has one attached,
        ///   and adds and returns a new one if it doesn't.
        /// </summary>
        /// <typeparam name="T">Type of the component to get or add.</typeparam>
        /// <param name="gameObject">Game object to get the component of.</param>
        /// <returns>
        ///   Component of type <typeparamref name="T" /> attached to the game object.
        /// </returns>
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            return gameObject.GetComponent<T>() ?? gameObject.AddComponent<T>();
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
        ///   Sets the layers of all queried game objects.
        /// </summary>
        /// <param name="gameObjects">Game objects to set the layers of.</param>
        /// <param name="layerName">Name of the new layer.</param>
        /// <returns>Query for further execution.</returns>
        public static Query<GameObject> SetLayers(this Query<GameObject> gameObjects, string layerName)
        {
            var layer = LayerMask.NameToLayer(layerName);
            foreach (var o in gameObjects)
            {
                o.layer = layer;
            }
            return gameObjects;
        }

        /// <summary>
        ///   Sets the tags of all queried game objects.
        /// </summary>
        /// <param name="gameObjects">Game objects to set the tags of.</param>
        /// <param name="tag">Name of the new tag.</param>
        /// <returns>Query for further execution.</returns>
        public static Query<GameObject> SetTags(this Query<GameObject> gameObjects, string tag)
        {
            foreach (var gameObject in gameObjects)
            {
                gameObject.tag = tag;
            }
            return gameObjects;
        }

        /// <summary>
        ///   Tries to get the component on the same <see cref="GameObject"/> of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">Type of the component to get.</typeparam>
        /// <param name="obj"><see cref="GameObject"/> to try to get the component of.</param>
        /// <param name="component">Found component, or <c>null</c> otherwise.</param>
        /// <returns><c>true</c> if a component was found, and <c>false</c> otherwise.</returns>
        public static bool TryGetComponent<T>(this GameObject obj, out T component)
        {
            component = obj.GetComponent<T>();
            return component != null;
        }

        #endregion
    }
}