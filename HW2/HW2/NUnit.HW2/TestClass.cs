// <copyright file="TestClass.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NUnit.HW2
{
    using System.Collections;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class TestClass
    {
        [Test]
        public void HashTest()
        {
            RandomList list = new RandomList();
            List<int> testList = new List<int>();

            // test empty list
            Assert.AreEqual(
                0, // expected value
                list.HashSet(testList)); // actual value

            // test for duplicates added in list
            testList.Add(0);
            testList.Add(0);

            Assert.AreEqual(
                1, // expected value
                list.HashSet(testList)); // actual value

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
                list.HashSet(testList)); // actual value
        }

        [Test]
        public void O1Test()
        {
            RandomList list = new RandomList();
            List<int> testList = new List<int>();

            // test empty list
            Assert.AreEqual(
                0, // expected value
                list.O1Storage(testList)); // actual value

            // test for duplicates added in list
            testList.Add(0);
            testList.Add(0);

            Assert.AreEqual(
                1, // expected value
                list.O1Storage(testList)); // actual value

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
                list.O1Storage(testList)); // actual value
        }

        [Test]
        public void SortedTest()
        {
            RandomList list = new RandomList();
            List<int> testList = new List<int>();

            // test empty list
            Assert.AreEqual(
                0, // expected value
                list.Sorted(testList)); // actual value

            // test for duplicates added in list
            testList.Add(0);
            testList.Add(0);

            Assert.AreEqual(
                1, // expected value
                list.Sorted(testList)); // actual value

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
                list.Sorted(testList)); // actual value
        }
    }
}
