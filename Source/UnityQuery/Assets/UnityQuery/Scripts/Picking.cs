// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Picking.cs" company="Nick Prühs">
//   Copyright (c) Nick Prühs. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace UnityQuery
{
    using UnityEngine;

    public static class Picking
    {
        #region Constants

        private const float DefaultDistance = 1000.0f;

        private const int DefaultLayerMask = -1;

        #endregion

        #region Properties

        private static Vector3 DefaultPosition
        {
            get
            {
                return Input.mousePosition;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///   Picks the object seen by the camera at the current mouse position.
        /// </summary>
        /// <param name="camera">Camera to cast the ray from.</param>
        /// <returns>
        ///   Object seen by the camera at the current mouse position, if any, and
        ///   <c>null</c> otherwise.
        /// </returns>
        public static Transform PickObject(this Camera camera)
        {
            return camera.PickObject(DefaultPosition);
        }

        /// <summary>
        ///   Picks the object seen by the camera at the specified screen point.
        /// </summary>
        /// <param name="camera">Camera to cast the ray from.</param>
        /// <param name="screenPosition">Screen point to cast the ray to.</param>
        /// <returns>
        ///   Object seen by the camera at the specified screen point, if any, and
        ///   <c>null</c> otherwise.
        /// </returns>
        public static Transform PickObject(this Camera camera, Vector3 screenPosition)
        {
            return camera.PickObject(screenPosition, DefaultLayerMask);
        }

        /// <summary>
        ///   Picks the object seen by the camera at the current mouse position.
        /// </summary>
        /// <param name="camera">Camera to cast the ray from.</param>
        /// <param name="layerMask">Layers of objects to pick.</param>
        /// <returns>
        ///   Object seen by the camera at the current mouse position, if any, and
        ///   <c>null</c> otherwise.
        /// </returns>
        public static Transform PickObject(this Camera camera, LayerMask layerMask)
        {
            return camera.PickObject(DefaultPosition, layerMask);
        }

        /// <summary>
        ///   Picks the object seen by the camera at the current mouse position.
        /// </summary>
        /// <param name="camera">Camera to cast the ray from.</param>
        /// <param name="maxDistance">Maximum distance to pick objects in.</param>
        /// <returns>
        ///   Object seen by the camera at the current mouse position, if any, and
        ///   <c>null</c> otherwise.
        /// </returns>
        public static Transform PickObject(this Camera camera, float maxDistance)
        {
            return camera.PickObject(DefaultPosition, maxDistance);
        }

        /// <summary>
        ///   Picks the object seen by the camera at the specified screen point.
        /// </summary>
        /// <param name="camera">Camera to cast the ray from.</param>
        /// <param name="screenPosition">Screen point to cast the ray to.</param>
        /// <param name="layerMask">Layers of objects to pick.</param>
        /// <returns>
        ///   Object seen by the camera at the specified screen point, if any, and
        ///   <c>null</c> otherwise.
        /// </returns>
        public static Transform PickObject(this Camera camera, Vector3 screenPosition, LayerMask layerMask)
        {
            return camera.PickObject(screenPosition, layerMask, DefaultDistance);
        }

        /// <summary>
        ///   Picks the object seen by the camera at the specified screen point.
        /// </summary>
        /// <param name="camera">Camera to cast the ray from.</param>
        /// <param name="screenPosition">Screen point to cast the ray to.</param>
        /// <param name="maxDistance">Maximum distance to pick objects in.</param>
        /// <returns>
        ///   Object seen by the camera at the specified screen point, if any, and
        ///   <c>null</c> otherwise.
        /// </returns>
        public static Transform PickObject(this Camera camera, Vector3 screenPosition, float maxDistance)
        {
            return camera.PickObject(screenPosition, DefaultLayerMask, maxDistance);
        }

        /// <summary>
        ///   Picks the object seen by the camera at the current mouse position.
        /// </summary>
        /// <param name="camera">Camera to cast the ray from.</param>
        /// <param name="layerMask">Layers of objects to pick.</param>
        /// <param name="maxDistance">Maximum distance to pick objects in.</param>
        /// <returns>
        ///   Object seen by the camera at the current mouse position, if any, and
        ///   <c>null</c> otherwise.
        /// </returns>
        public static Transform PickObject(this Camera camera, LayerMask layerMask, float maxDistance)
        {
            return camera.PickObject(DefaultPosition, layerMask, maxDistance);
        }

        /// <summary>
        ///   Picks the object seen by the camera at the specified screen point.
        /// </summary>
        /// <param name="camera">Camera to cast the ray from.</param>
        /// <param name="screenPosition">Screen point to cast the ray to.</param>
        /// <param name="layerMask">Layers of objects to pick.</param>
        /// <param name="maxDistance">Maximum distance to pick objects in.</param>
        /// <returns>
        ///   Object seen by the camera at the specified screen point, if any, and
        ///   <c>null</c> otherwise.
        /// </returns>
        public static Transform PickObject(
            this Camera camera,
            Vector3 screenPosition,
            LayerMask layerMask,
            float maxDistance)
        {
            var ray = camera.ScreenPointToRay(screenPosition);
            RaycastHit hitInfo;
            return Physics.Raycast(ray, out hitInfo, maxDistance, layerMask) ? hitInfo.transform : null;
        }

        #endregion
    }
}