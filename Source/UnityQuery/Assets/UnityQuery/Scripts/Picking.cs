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

        private static readonly Plane DefaultPlane = new Plane(Vector3.up, Vector3.zero);

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
        ///   Picks the object seen by the camera at the specified screen position.
        /// </summary>
        /// <param name="camera">Camera to cast the ray from.</param>
        /// <param name="screenPosition">Screen position to cast the ray to.</param>
        /// <returns>
        ///   Object seen by the camera at the specified screen position, if any, and
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
        ///   Picks the object seen by the camera at the specified screen position.
        /// </summary>
        /// <param name="camera">Camera to cast the ray from.</param>
        /// <param name="screenPosition">Screen position to cast the ray to.</param>
        /// <param name="layerMask">Layers of objects to pick.</param>
        /// <returns>
        ///   Object seen by the camera at the specified screen position, if any, and
        ///   <c>null</c> otherwise.
        /// </returns>
        public static Transform PickObject(this Camera camera, Vector3 screenPosition, LayerMask layerMask)
        {
            return camera.PickObject(screenPosition, layerMask, DefaultDistance);
        }

        /// <summary>
        ///   Picks the object seen by the camera at the specified screen position.
        /// </summary>
        /// <param name="camera">Camera to cast the ray from.</param>
        /// <param name="screenPosition">Screen position to cast the ray to.</param>
        /// <param name="maxDistance">Maximum distance to pick objects in.</param>
        /// <returns>
        ///   Object seen by the camera at the specified screen position, if any, and
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
        ///   Picks the object seen by the camera at the specified screen position.
        /// </summary>
        /// <param name="camera">Camera to cast the ray from.</param>
        /// <param name="screenPosition">Screen position to cast the ray to.</param>
        /// <param name="layerMask">Layers of objects to pick.</param>
        /// <param name="maxDistance">Maximum distance to pick objects in.</param>
        /// <returns>
        ///   Object seen by the camera at the specified screen position, if any, and
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

        /// <summary>
        ///   Picks the world position on the XZ plane seen by the camera at the current mouse position.
        /// </summary>
        /// <param name="camera">Camera to cast the ray from.</param>
        /// <param name="position">Plane position seen by the camera at the current mouse position.</param>
        /// <returns>
        ///   <c>true</c>, if any position on the XZ plane was seen by the camera at the current mouse position, and
        ///   <c>false</c> otherwise.
        /// </returns>
        public static bool PickPosition(this Camera camera, out Vector3 position)
        {
            return camera.PickPosition(DefaultPosition, out position);
        }

        /// <summary>
        ///   Picks the world position on the XZ plane seen by the camera at the specified screen position.
        /// </summary>
        /// <param name="camera">Camera to cast the ray from.</param>
        /// <param name="screenPosition">Screen position to cast the ray to.</param>
        /// <param name="position">Plane position seen by the camera at the specified screen position.</param>
        /// <returns>
        ///   <c>true</c>, if any position on the XZ plane was seen by the camera at the specified screen position, and
        ///   <c>false</c> otherwise.
        /// </returns>
        public static bool PickPosition(this Camera camera, Vector3 screenPosition, out Vector3 position)
        {
            return camera.PickPosition(screenPosition, DefaultPlane, out position);
        }

        /// <summary>
        ///   Picks the plane position seen by the camera at the current mouse position.
        /// </summary>
        /// <param name="camera">Camera to cast the ray from.</param>
        /// <param name="plane">Plane to cast the ray against.</param>
        /// <param name="position">Plane position seen by the camera at the current mouse position.</param>
        /// <returns>
        ///   <c>true</c>, if any position on the plane was seen by the camera at the current mouse position, and
        ///   <c>false</c> otherwise.
        /// </returns>
        public static bool PickPosition(this Camera camera, Plane plane, out Vector3 position)
        {
            return camera.PickPosition(DefaultPosition, plane, out position);
        }

        /// <summary>
        ///   Picks the plane position seen by the camera at the specified screen position.
        /// </summary>
        /// <param name="camera">Camera to cast the ray from.</param>
        /// <param name="screenPosition">Screen position to cast the ray to.</param>
        /// <param name="plane">Plane to cast the ray against.</param>
        /// <param name="position">Plane position seen by the camera at the specified screen position.</param>
        /// <returns>
        ///   <c>true</c>, if any position on the plane was seen by the camera at the specified screen position, and
        ///   <c>false</c> otherwise.
        /// </returns>
        public static bool PickPosition(this Camera camera, Vector3 screenPosition, Plane plane, out Vector3 position)
        {
            float distance;
            var ray = camera.ScreenPointToRay(screenPosition);

            if (plane.Raycast(ray, out distance))
            {
                position = ray.GetPoint(distance);
                return true;
            }

            position = Vector3.zero;
            return false;
        }

        #endregion
    }
}