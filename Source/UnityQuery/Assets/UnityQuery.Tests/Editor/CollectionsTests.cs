// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollectionsTests.cs" company="Nick Prühs">
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
        public void TestContainsAll()
        {
            // Arrange.
            var first = new List<int> { 1, 2, 3 };
            var second = new List<int> { 1, 3 };
            var third = new List<int> { 1, 2, 4 };

            // Assert.
            Assert.IsTrue(first.ContainsAll(second));
            Assert.IsFalse(first.ContainsAll(third));
        }

        [Test]
        public void TestGetValueOrDefault()
        {
            // Arrange.
            var dictionary = new Dictionary<string, int>();
            dictionary.Add("one", 1);

            // Assert.
            Assert.AreEqual(1, dictionary.GetValueOrDefault("one", 0));

            Assert.AreEqual(0, dictionary.GetValueOrDefault("two"));
            Assert.AreEqual(0, dictionary.GetValueOrDefault("two", 0));
        }

        [Test]
        public void TestIndexOfElement()
        {
            // Arrange.
            IEnumerable<int> list = new List<int> { 1, 2, 3 };

            // Assert.
            Assert.AreEqual(0, list.IndexOf(1));
            Assert.AreEqual(2, list.IndexOf(3));
            Assert.AreEqual(-1, list.IndexOf(5));
        }

        [Test]
        public void TestIndexOfPredicate()
        {
            // Arrange.
            IEnumerable<int> list = new List<int> { 1, 2, 3 };

            // Assert.
            Assert.AreEqual(2, list.IndexOf(i => i > 2));
        }

        [Test]
        public void TestNullOrEmpty()
        {
            // Arrange.
            var sequence = new List<int> { 1, 2, 3 };
            var emptySequence = new List<int>();
            List<int> nullSequence = null;

            // Assert.
            Assert.IsFalse(sequence.IsNullOrEmpty());

            Assert.IsTrue(emptySequence.IsNullOrEmpty());
            Assert.IsTrue(nullSequence.IsNullOrEmpty());
        }

        [Test]
        public void TestToString()
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