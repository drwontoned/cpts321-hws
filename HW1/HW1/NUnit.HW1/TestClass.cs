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
            // one number string test
            string oneNum = "1"; 
             Assert.AreEqual(
                1, //expected value
                splitString(oneNum).Length); // actual value

            // two number string test
            string twoNum = "1 2"; 
            Assert.AreEqual(
                2, //expected value
                splitString(twoNum).Length); // actual value

            // three number string
            string threeNum = "1 2 3"; 
            Assert.AreEqual(
                3, //expected value
                splitString(threeNum).Length); // actual value

            // three number string of duplicates test
            string threeDupes = "1 1 1"; 
            Assert.AreEqual(
                1, //expected value
                splitString(threeDupes).Length); // actual value
        }

        [Test]
        public void TestNewNode()
        {
            // creation of node to be tested with a value of 1
            Node testNode1 = new Node(1); 

            Assert.AreEqual(
                1, // expected value
                testNode.Value); // actual value
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

        [Test]
        public void TestSortedOrder()
        {
            // set up new test tree to test 7 insertions not in sorted order
            BinarySearchTree testTree = new BinarySearchTree();
            testTree.Root = testTree.Insert(testTree.Root, 3);
            testTree.Root = testTree.Insert(testTree.Root, 2);
            testTree.Root = testTree.Insert(testTree.Root, 1);
            testTree.Root = testTree.Insert(testTree.Root, 0);
            testTree.Root = testTree.Insert(testTree.Root, 6);
            testTree.Root = testTree.Insert(testTree.Root, 5);
            testTree.Root = testTree.Insert(testTree.Root, 4);

            Assert.AreEqual(
                "0 1 2 3 4 5 6", // expected value
                testTree.getSortedOrder()); // actual value
        }

        [Test]
        public void TestCount()
        {
            // set up new test tree to test 7 insertions
            BinarySearchTree testTree = new BinarySearchTree();
            testTree.Root = testTree.Insert(testTree.Root, 3);
            testTree.Root = testTree.Insert(testTree.Root, 2);
            testTree.Root = testTree.Insert(testTree.Root, 1);
            testTree.Root = testTree.Insert(testTree.Root, 0);
            testTree.Root = testTree.Insert(testTree.Root, 6);
            testTree.Root = testTree.Insert(testTree.Root, 5);
            testTree.Root = testTree.Insert(testTree.Root, 4);

            Assert.AreEqual(
                7, // expected value
                testTree.Count()); // actual value
        }

        [Test]
        public void TestDepth()
        {
            // set up new test tree to test 7 insertions not in sorted order
            BinarySearchTree testTree = new BinarySearchTree();
            testTree.Root = testTree.Insert(testTree.Root, 3);
            testTree.Root = testTree.Insert(testTree.Root, 2);
            testTree.Root = testTree.Insert(testTree.Root, 1);
            testTree.Root = testTree.Insert(testTree.Root, 0);
            testTree.Root = testTree.Insert(testTree.Root, 6);
            testTree.Root = testTree.Insert(testTree.Root, 5);
            testTree.Root = testTree.Insert(testTree.Root, 4);

            Assert.AreEqual(
                3, // expected value
                testTree.Depth()); // actual value

            // set up new test tree to test 7 insertions in sorted order
            testTree = new BinarySearchTree();
            testTree.Root = testTree.Insert(testTree.Root, 0);
            testTree.Root = testTree.Insert(testTree.Root, 1);
            testTree.Root = testTree.Insert(testTree.Root, 2);
            testTree.Root = testTree.Insert(testTree.Root, 3);
            testTree.Root = testTree.Insert(testTree.Root, 4);
            testTree.Root = testTree.Insert(testTree.Root, 5);
            testTree.Root = testTree.Insert(testTree.Root, 6);

            Assert.AreEqual(
                7, // expected value
                testTree.Depth()); // actual value
        }

        [Test]
        public void TestMinDepth()
        {
            // set up new test tree to test 7 insertions in sorted order
            testTree = new BinarySearchTree();
            testTree.Root = testTree.Insert(testTree.Root, 0);
            testTree.Root = testTree.Insert(testTree.Root, 1);
            testTree.Root = testTree.Insert(testTree.Root, 2);
            testTree.Root = testTree.Insert(testTree.Root, 3);
            testTree.Root = testTree.Insert(testTree.Root, 4);
            testTree.Root = testTree.Insert(testTree.Root, 5);
            testTree.Root = testTree.Insert(testTree.Root, 6);

            Assert.AreEqual(
                3, // expected value
                testTree.MinDepth()); // actual value
        }

    }
}
