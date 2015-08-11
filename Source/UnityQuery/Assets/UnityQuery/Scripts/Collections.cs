// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Collections.cs" company="Nick Prühs">
//   Copyright (c) Nick Prühs. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace UnityQuery
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class Collections
    {
        #region Public Methods and Operators

        /// <summary>
        ///   Checks whether a sequence contains all elements of another one.
        /// </summary>
        /// <typeparam name="T">Type of the elements of the sequence to check.</typeparam>
        /// <param name="first">Containing sequence.</param>
        /// <param name="second">Contained sequence.</param>
        /// <returns>
        ///   <c>true</c>, if the sequence contains all elements of the other one, and
        ///   <c>false</c> otherwise.
        /// </returns>
        public static bool ContainsAll<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            return second.All(first.Contains);
        }

        /// <summary>
        ///   Tries to get the value with the specified key from the
        ///   dictionary, and returns the passed default value if the key
        ///   could not be found.
        /// </summary>
        /// <typeparam name="TKey">Type of the dictionary keys.</typeparam>
        /// <typeparam name="TValue">Type of the dictionary values.</typeparam>
        /// <param name="dictionary">
        ///   Dictionary to get the value from.
        /// </param>
        /// <param name="key">
        ///   Key of the value to get.
        /// </param>
        /// <param name="defaultValue">
        ///   Default value to return if the specified key could not be found.
        /// </param>
        /// <returns>
        ///   Value with the specified <paramref name="key" />, if found,
        ///   and <paramref name="defaultValue" /> otherwise.
        /// </returns>
        public static TValue GetValueOrDefault<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            TValue defaultValue)
        {
            TValue value;
            return dictionary.TryGetValue(key, out value) ? value : defaultValue;
        }

        /// <summary>
        ///   Tries to get the value with the specified key from the
        ///   dictionary, and returns the default value of the key type
        ///   if the key could not be found.
        /// </summary>
        /// <typeparam name="TKey">Type of the dictionary keys.</typeparam>
        /// <typeparam name="TValue">Type of the dictionary values.</typeparam>
        /// <param name="dictionary">
        ///   Dictionary to get the value from.
        /// </param>
        /// <param name="key">
        ///   Key of the value to get.
        /// </param>
        /// <returns>
        ///   Value with the specified <paramref name="key" />, if found,
        ///   and the default value of <typeparamref name="TValue" /> otherwise.
        /// </returns>
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            TValue value;
            return dictionary.TryGetValue(key, out value) ? value : default(TValue);
        }

        /// <summary>
        ///   Returns the zero-based index of the first occurrence of the specified item in a sequence.
        /// </summary>
        /// <typeparam name="T">Type of the elements of the sequence.</typeparam>
        /// <param name="items">Sequence to search.</param>
        /// <param name="item">Item to search for.</param>
        /// <returns>
        ///   Index of the specified item, if it could be found,
        ///   and <c>-1</c> otherwise.
        /// </returns>
        public static int IndexOf<T>(this IEnumerable<T> items, T item)
        {
            var index = 0;

            foreach (var i in items)
            {
                if (Equals(i, item))
                {
                    return index;
                }

                ++index;
            }

            return -1;
        }

        /// <summary>
        ///   Returns the zero-based index of the first  item in a sequence that satisfies a condition.
        /// </summary>
        /// <typeparam name="T">Type of the elements of the sequence.</typeparam>
        /// <param name="items">Sequence to search.</param>
        /// <param name="predicate">Function to test each element for a condition..</param>
        /// <returns>
        ///   Index of the first item satisfying the condition, if any could be found,
        ///   and <c>-1</c> otherwise.
        /// </returns>
        public static int IndexOf<T>(this IEnumerable<T> items, Func<T, bool> predicate)
        {
            var index = 0;

            foreach (var i in items)
            {
                if (predicate(i))
                {
                    return index;
                }

                ++index;
            }

            return -1;
        }

        /// <summary>
        ///   Determines whether a sequence is null or doesn't contain any elements.
        /// </summary>
        /// <typeparam name="T">Type of the elements of the sequence to check.</typeparam>
        /// <param name="sequence">Sequence to check. </param>
        /// <returns>
        ///   <c>true</c> if the sequence is null or empty, and
        ///   <c>false</c> otherwise.
        /// </returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> sequence)
        {
            if (sequence == null)
            {
                return true;
            }

            return !sequence.Any();
        }

        /// <summary>
        ///   Returns a comma-separated string that represents a sequence.
        /// </summary>
        /// <param name="sequence">Sequence to get a textual representation of.</param>
        /// <returns>Comma-separated string that represents the sequence.</returns>
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