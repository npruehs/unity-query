// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollectionTests.cs" company="Nick Prühs">
//   Copyright (c) Nick Prühs. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace UnityQuery.Tests
{
    using System.Collections.Generic;

    using NUnit.Framework;

    public class CollectionsTests
    {
        #region Public Methods and Operators

        [Test]
        public void TestSequenceToString()
        {
            // Arrange.
            var list = new List<int> { 1, 2, 3 };

            // Act.
            var s = list.SequenceToString();

            // Assert.
            Assert.AreEqual("[1,2,3]", s);
        }

        #endregion
    }
}