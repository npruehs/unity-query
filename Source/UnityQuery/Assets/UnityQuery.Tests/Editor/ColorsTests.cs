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

        private const byte ByteAlpha = 4;

        private const byte ByteBlue = 3;

        private const byte ByteGreen = 2;

        private const byte ByteRed = 1;

        private const float FloatAlpha = 0.4f;

        private const float FloatBlue = 0.3f;

        private const float FloatGreen = 0.2f;

        private const float FloatRed = 0.1f;

        #endregion

        #region Public Methods and Operators

        [Test]
        public void TestColorWithByteAlpha()
        {
            // Arrange.
            Color32 before = new Color32(ByteRed, ByteGreen, ByteBlue, ByteAlpha);
            const byte NewAlpha = 5;

            // Act.
            Color32 after = ((Color)before).WithAlpha(NewAlpha);

            // Assert.
            Assert.AreEqual(before.r, after.r);
            Assert.AreEqual(before.g, after.g);
            Assert.AreEqual(before.b, after.b);
            Assert.AreEqual(NewAlpha, after.a);
        }

        [Test]
        public void TestColorWithByteBlue()
        {
            // Arrange.
            Color32 before = new Color32(ByteRed, ByteGreen, ByteBlue, ByteAlpha);
            const byte NewBlue = 5;

            // Act.
            Color32 after = ((Color)before).WithBlue(NewBlue);

            // Assert.
            Assert.AreEqual(before.r, after.r);
            Assert.AreEqual(before.g, after.g);
            Assert.AreEqual(NewBlue, after.b);
            Assert.AreEqual(before.a, after.a);
        }

        [Test]
        public void TestColorWithByteGreen()
        {
            // Arrange.
            Color32 before = new Color32(ByteRed, ByteGreen, ByteBlue, ByteAlpha);
            const byte NewGreen = 5;

            // Act.
            Color32 after = ((Color)before).WithGreen(NewGreen);

            // Assert.
            Assert.AreEqual(before.r, after.r);
            Assert.AreEqual(NewGreen, after.g);
            Assert.AreEqual(before.b, after.b);
            Assert.AreEqual(before.a, after.a);
        }

        [Test]
        public void TestColorWithByteRed()
        {
            // Arrange.
            Color32 before = new Color32(ByteRed, ByteGreen, ByteBlue, ByteAlpha);
            const byte NewRed = 5;

            // Act.
            Color32 after = ((Color)before).WithRed(NewRed);

            // Assert.
            Assert.AreEqual(NewRed, after.r);
            Assert.AreEqual(before.g, after.g);
            Assert.AreEqual(before.b, after.b);
            Assert.AreEqual(before.a, after.a);
        }

        [Test]
        public void TestColorWithFloatAlpha()
        {
            // Arrange.
            var before = new Color(FloatRed, FloatGreen, FloatBlue, FloatAlpha);
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
        public void TestColorWithFloatBlue()
        {
            // Arrange.
            var before = new Color(FloatRed, FloatGreen, FloatBlue, FloatAlpha);
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
        public void TestColorWithFloatGreen()
        {
            // Arrange.
            var before = new Color(FloatRed, FloatGreen, FloatBlue, FloatAlpha);
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
        public void TestColorWithFloatRed()
        {
            // Arrange.
            var before = new Color(FloatRed, FloatGreen, FloatBlue, FloatAlpha);
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