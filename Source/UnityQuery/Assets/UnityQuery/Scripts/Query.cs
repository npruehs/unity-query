// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Query.cs" company="Nick Prühs">
//   Copyright (c) Nick Prühs. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace UnityQuery
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///   Wraps a sequence of objects, forcing immediate execution of an
    ///   enumeration.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Query<T> : IEnumerable<T>
    {
        #region Fields

        private readonly List<T> sequence;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///   Wraps the passed sequence of objects, forcing immediate execution.
        /// </summary>
        /// <param name="sequence"></param>
        public Query(IEnumerable<T> sequence)
        {
            this.sequence = sequence.ToList();
        }

        /// <summary>
        ///   Wraps the passed sequence of objects, forcing immediate execution.
        /// </summary>
        /// <param name="sequence"></param>
        public Query(List<T> sequence)
        {
            this.sequence = sequence;
        }

        #endregion

        #region Public Methods and Operators

        public IEnumerator<T> GetEnumerator()
        {
            return this.sequence.GetEnumerator();
        }

        #endregion

        #region Methods

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion
    }
}