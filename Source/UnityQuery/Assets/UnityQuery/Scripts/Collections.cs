// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Collections.cs" company="Nick Prühs">
//   Copyright (c) Nick Prühs. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace UnityQuery
{
    using System.Collections;
    using System.Text;

    public static class Collections
    {
        #region Public Methods and Operators

        public static string SequenceToString(this IEnumerable sequence)
        {
            // Check empty sequence.
            if (sequence == null)
            {
                return "null";
            }

            var stringBuilder = new StringBuilder();

            // Add opening bracket.
            stringBuilder.Append("[");

            foreach (var element in sequence)
            {
                var elementString = element as string;
                if (elementString == null)
                {
                    // Handle nested enumerables.
                    var elementEnumerable = element as IEnumerable;
                    elementString = elementEnumerable != null
                        ? elementEnumerable.SequenceToString()
                        : element.ToString();
                }

                // Add comma.
                stringBuilder.AppendFormat("{0},", elementString);
            }

            // Empty sequence.
            if (stringBuilder.Length <= 1)
            {
                return "[]";
            }

            // Add closing bracket.
            stringBuilder[stringBuilder.Length - 1] = ']';
            return stringBuilder.ToString();
        }

        #endregion
    }
}