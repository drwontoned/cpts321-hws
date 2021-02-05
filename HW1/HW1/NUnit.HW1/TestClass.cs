// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace NUnit.HW1
{
    [TestFixture]
    public class TestClass
    {

        [Test]
        public void TestSplitString()
        {
            string oneNum = "1"; // one number string
            string twoNum = "1 2"; // two number string
            string threeNum = "1 2 3"; // three number string


            Assert.AreEqual(
                1, //expected value
                splitString(oneNum).Length); // actual value

            Assert.AreEqual(
                2, //expected value
                splitString(oneNum).Length); // actual value

            Assert.AreEqual(
                3, //expected value
                splitString(oneNum).Length); // actual value
        }

        [Test]
        public void TestNewNode()
        {
            Node testNode1 = new Node(1); // creation of node to be tested with a value of 1

            Assert.AreEqual(
                1, // expected value
                testNode.getValue); // actual value
        }

        [Test]
        public void TestTreeInsertion()
        {
            // set up new test tree to test 1 insertion
            BinarySearchTree testTree = new BinarySearchTree();
            testTree.Root = testTree.Insert(testTree.Root, 0);

            Assert.AreEqual(
                0, // expected value
                testTree.Root.Value); // actual value

            Assert.AreEqual(
                null, // expected value
                testTree.Root.LeftChild); // actual value

            Assert.AreEqual(
                null, // expected value
                testTree.Root.RightChild); // actual value


            // set up new test tree to test 2 insertion causing a right child
            testTree = new BinarySearchTree();
            testTree.Root = testTree.Insert(testTree.Root, 0);
            testTree.Root = testTree.Insert(testTree.Root, 1);
            Assert.AreEqual(
                0, // expected value
                testTree.Root.Value); // actual value

            Assert.AreEqual(
                null, // expected value
                testTree.Root.LeftChild); // actual value

            Assert.AreEqual(
                1, // expected value
                testTree.Root.RightChild); // actual value


            // set up new test tree to test 2 insertion causing a left child
            testTree = new BinarySearchTree();
            testTree.Root = testTree.Insert(testTree.Root, 1);
            testTree.Root = testTree.Insert(testTree.Root, 0);
            Assert.AreEqual(
                1, // expected value
                testTree.Root.Value); // actual value

            Assert.AreEqual(
                0, // expected value
                testTree.Root.LeftChild); // actual value

            Assert.AreEqual(
                null, // expected value
                testTree.Root.RightChild); // actual value


            // set up new test tree to test 3 insertion causing a left and right child
            testTree = new BinarySearchTree();
            testTree.Root = testTree.Insert(testTree.Root, 1);
            testTree.Root = testTree.Insert(testTree.Root, 2);
            testTree.Root = testTree.Insert(testTree.Root, 0);
            Assert.AreEqual(
                1, // expected value
                testTree.Root.Value); // actual value

            Assert.AreEqual(
                0, // expected value
                testTree.Root.LeftChild); // actual value

            Assert.AreEqual(
                2, // expected value
                testTree.Root.RightChild); // actual value
        }

    }
}
