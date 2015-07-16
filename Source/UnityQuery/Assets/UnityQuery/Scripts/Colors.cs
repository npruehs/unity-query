// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Colors.cs" company="Nick Prühs">
//   Copyright (c) Nick Prühs. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace UnityQuery
{
    using UnityEngine;

    public static class Colors
    {
        #region Public Methods and Operators

        public static Color WithAlpha(this Color c, float newAlpha)
        {
            return new Color(c.r, c.g, c.b, newAlpha);
        }

        public static Color WithAlpha(this Color c, byte newAlpha)
        {
            Color32 color = c;
            return new Color32(color.r, color.g, color.b, newAlpha);
        }

        public static Color WithBlue(this Color c, float newBlue)
        {
            return new Color(c.r, c.g, newBlue, c.a);
        }

        public static Color WithBlue(this Color c, byte newBlue)
        {
            Color32 color = c;
            return new Color32(color.r, color.g, newBlue, color.a);
        }

        public static Color WithGreen(this Color c, float newGreen)
        {
            return new Color(c.r, newGreen, c.b, c.a);
        }

        public static Color WithGreen(this Color c, byte newGreen)
        {
            Color32 color = c;
            return new Color32(color.r, newGreen, color.b, color.a);
        }

        public static Color WithRed(this Color c, float newRed)
        {
            return new Color(newRed, c.g, c.b, c.a);
        }

        public static Color WithRed(this Color c, byte newRed)
        {
            Color32 color = c;
            return new Color32(newRed, color.g, color.b, color.a);
        }

        #endregion
    }
}