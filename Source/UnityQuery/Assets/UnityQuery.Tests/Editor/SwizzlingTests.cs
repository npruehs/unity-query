// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SwizzlingTests.cs" company="Nick Prühs">
//   Copyright (c) Nick Prühs. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace UnityQuery.Tests
{
    using NUnit.Framework;

    using UnityEngine;

    public class SwizzlingTests
    {
        #region Constants

        private const float X = 1;

        private const float Y = 2;

        private const float Z = 3;

        #endregion

        #region Public Methods and Operators

        [Test]
        public void TestVector2WithX()
        {
            // Arrange.
            var u = new Vector2(X, Y);
            const int NewX = 4;

            // Act.
            var v = u.WithX(NewX);

            // Assert.
            Assert.AreEqual(NewX, v.x);
            Assert.AreEqual(u.y, v.y);
        }

        [Test]
        public void TestVector2WithY()
        {
            // Arrange.
            var u = new Vector2(X, Y);
            const int NewY = 4;

            // Act.
            var v = u.WithY(NewY);

            // Assert.
            Assert.AreEqual(u.x, v.x);
            Assert.AreEqual(NewY, v.y);
        }

        [Test]
        public void TestVector3WithX()
        {
            // Arrange.
            var u = new Vector3(X, Y, Z);
            const int NewX = 4;

            // Act.
            var v = u.WithX(NewX);

            // Assert.
            Assert.AreEqual(NewX, v.x);
            Assert.AreEqual(u.y, v.y);
            Assert.AreEqual(u.z, v.z);
        }

        [Test]
        public void TestVector3WithY()
        {
            // Arrange.
            var u = new Vector3(X, Y, Z);
            const int NewY = 4;

            // Act.
            var v = u.WithY(NewY);

            // Assert.
            Assert.AreEqual(u.x, v.x);
            Assert.AreEqual(NewY, v.y);
            Assert.AreEqual(u.z, v.z);
        }

        [Test]
        public void TestVector3WithZ()
        {
            // Arrange.
            var u = new Vector3(X, Y, Z);
            const int NewZ = 4;

            // Act.
            var v = u.WithZ(NewZ);

            // Assert.
            Assert.AreEqual(u.x, v.x);
            Assert.AreEqual(u.y, v.y);
            Assert.AreEqual(NewZ, v.z);
        }

        [Test]
        public void TestVector3XY()
        {
            // Arrange.
            var u = new Vector3(X, Y, Z);

            // Act.
            var v = u.XY();

            // Assert.
            Assert.AreEqual(X, v.x);
            Assert.AreEqual(Y, v.y);
        }

        [Test]
        public void TestVector3XZ()
        {
            // Arrange.
            var u = new Vector3(X, Y, Z);

            // Act.
            var v = u.XZ();

            // Assert.
            Assert.AreEqual(X, v.x);
            Assert.AreEqual(Z, v.y);
        }

        [Test]
        public void TestVector3YZ()
        {
            // Arrange.
            var u = new Vector3(X, Y, Z);

            // Act.
            var v = u.YZ();

            // Assert.
            Assert.AreEqual(Y, v.x);
            Assert.AreEqual(Z, v.y);
        }

        #endregion
    }
}