// <copyright file="TestClass.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NUnit.HW2
{
    using System.Collections;
    using System.Collections.Generic;
    using global::HW2;
    using NUnit.Framework;

    /// <summary>
    /// Test class where all functionality within program is tested.
    /// </summary>
    [TestFixture]
    public class TestClass
    {

        /// <summary>
        /// Tests for the HashSet method.
        /// </summary>
        [Test]
        public void HashTest()
        {
            RandomList list = new RandomList();
            List<int> testList = new List<int>();

            // test empty list
            Assert.AreEqual(
                0, // expected value
                list.HashSetUnique(testList)); // actual value

            // test for duplicates added in list
            testList.Add(0);
            testList.Add(0);

            Assert.AreEqual(
                1, // expected value
                list.HashSetUnique(testList)); // actual value

            // test for different integers with duplicates added out of order
            testList.Add(1);
            testList.Add(4);
            testList.Add(2);
            testList.Add(3);
            testList.Add(3);
            testList.Add(2);
            testList.Add(4);
            testList.Add(1);

            Assert.AreEqual(
                5, // expected value
                list.HashSetUnique(testList)); // actual value
        }

        /// <summary>
        /// Tests for the O1Storage method.
        /// </summary>
        [Test]
        public void O1Test()
        {
            RandomList list = new RandomList();
            List<int> testList = new List<int>();

            // test empty list
            Assert.AreEqual(
                0, // expected value
                list.O1StorageUnique(testList)); // actual value

            // test for duplicates added in list
            testList.Add(0);
            testList.Add(0);

            Assert.AreEqual(
                1, // expected value
                list.O1StorageUnique(testList)); // actual value

            // test for different integers with duplicates added out of order
            testList.Add(1);
            testList.Add(4);
            testList.Add(2);
            testList.Add(3);
            testList.Add(3);
            testList.Add(2);
            testList.Add(4);
            testList.Add(1);

            Assert.AreEqual(
                5, // expected value
                list.O1StorageUnique(testList)); // actual value
        }

        /// <summary>
        /// Tests for the Sorted method.
        /// </summary>
        [Test]
        public void SortedTest()
        {
            RandomList list = new RandomList();
            List<int> testList = new List<int>();

            // test empty list
            Assert.AreEqual(
                0, // expected value
                list.SortedUnique(testList)); // actual value

            // test for duplicates added in list
            testList.Add(0);
            testList.Add(0);

            Assert.AreEqual(
                1, // expected value
                list.SortedUnique(testList)); // actual value

            // test for different integers with duplicates added out of order
            testList.Add(1);
            testList.Add(4);
            testList.Add(2);
            testList.Add(3);
            testList.Add(3);
            testList.Add(2);
            testList.Add(4);
            testList.Add(1);

            Assert.AreEqual(
                5, // expected value
                list.SortedUnique(testList)); // actual value
        }

        /// <summary>
        /// Tests if the 3 methods result in the same output.
        /// </summary>
        [Test]
        public void AllSameTest()
        {
            RandomList list = new RandomList();
            List<int> testList = new List<int>();

            // test for different integers with duplicates added out of order
            testList.Add(1);
            testList.Add(4);
            testList.Add(2);
            testList.Add(3);
            testList.Add(3);
            testList.Add(2);
            testList.Add(4);
            testList.Add(1);

            Assert.AreEqual(
                list.HashSetUnique(testList), // HashSet method value
                list.O1StorageUnique(testList), // O1Storage method value
                list.SortedUnique(testList)); // Sorted method value
        }
    }
}
