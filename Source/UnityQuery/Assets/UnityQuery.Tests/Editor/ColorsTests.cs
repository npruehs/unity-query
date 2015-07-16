// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorsTests.cs" company="Nick Prühs">
//   Copyright (c) Nick Prühs. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace UnityQuery.Tests
{
    using NUnit.Framework;

    using UnityEngine;

    public class ColorsTests
    {
        #region Constants

        private const float A = 0.4f;

        private const float B = 0.3f;

        private const float G = 0.2f;

        private const float R = 0.1f;

        #endregion

        #region Public Methods and Operators

        [Test]
        public void TestColorWithA()
        {
            // Arrange.
            var before = new Color(R, G, B, A);
            const float NewAlpha = 0.5f;

            // Act.
            var after = before.WithAlpha(NewAlpha);

            // Assert.
            Assert.AreEqual(before.r, after.r);
            Assert.AreEqual(before.g, after.g);
            Assert.AreEqual(before.b, after.b);
            Assert.AreEqual(NewAlpha, after.a);
        }

        [Test]
        public void TestColorWithB()
        {
            // Arrange.
            var before = new Color(R, G, B, A);
            const float NewBlue = 0.5f;

            // Act.
            var after = before.WithBlue(NewBlue);

            // Assert.
            Assert.AreEqual(before.r, after.r);
            Assert.AreEqual(before.g, after.g);
            Assert.AreEqual(NewBlue, after.b);
            Assert.AreEqual(before.a, after.a);
        }

        [Test]
        public void TestColorWithG()
        {
            // Arrange.
            var before = new Color(R, G, B, A);
            const float NewGreen = 0.5f;

            // Act.
            var after = before.WithGreen(NewGreen);

            // Assert.
            Assert.AreEqual(before.r, after.r);
            Assert.AreEqual(NewGreen, after.g);
            Assert.AreEqual(before.b, after.b);
            Assert.AreEqual(before.a, after.a);
        }

        [Test]
        public void TestColorWithR()
        {
            // Arrange.
            var before = new Color(R, G, B, A);
            const float NewRed = 0.5f;

            // Act.
            var after = before.WithRed(NewRed);

            // Assert.
            Assert.AreEqual(NewRed, after.r);
            Assert.AreEqual(before.g, after.g);
            Assert.AreEqual(before.b, after.b);
            Assert.AreEqual(before.a, after.a);
        }

        #endregion
    }
}