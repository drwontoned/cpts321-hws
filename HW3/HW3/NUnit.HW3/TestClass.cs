// <copyright file="TestClass.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NUnit.HW3
{
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using global::HW3;
    using NUnit.Framework;

    [TestFixture]
    public class TestClass
    {
        private HW3 testWindow = new HW3(); // instance of a HW3 win form app to test

        /// <summary>
        /// Test saving and loading a file into a text box.
        /// </summary>
        [Test]
        public void TestSaveLoad()
        {
            string fileName = "\\testFile.txt"; // create test file name
            string path = Directory.GetCurrentDirectory() + fileName; // create file path

            // Create file stream for the path
            FileStream file = new FileStream(
                path,
                FileMode.OpenOrCreate,
                FileAccess.ReadWrite,
                FileShare.None);

            string testWorked = "wow"; // string to fill in text box
            this.testWindow.ActiveControl.Text = testWorked; // fill in text box with testWorked string
            MethodInfo mInfo = this.GetMethod("SaveText"); // get SaveText method from instance of HW3
            mInfo.Invoke(this.testWindow, new object[] { file }); // invoke SaveText with the FileStream
            file.Close(); // close out of filestream
            this.testWindow.ActiveControl.Text = string.Empty; // empty the text box

            // Recreate filestream now that SaveText has been invoked
            file = new FileStream(
                path,
                FileMode.OpenOrCreate,
                FileAccess.ReadWrite,
                FileShare.None);

            mInfo = this.GetMethod("LoadText"); // get LoadText method from instance of HW3
            mInfo.Invoke(this.testWindow, new object[] { new StreamReader(file) }); // invoke LoadText with a StreamReader of the FileStream

            // Test 1 is dealing with an initially empty text box having text added to it
            // then having that text saved into a file then loading that text back into the text box.
            Assert.AreEqual(
                testWorked,
                this.testWindow.ActiveControl.Text);

            // Test 2 is dealing with an already filled text box having more text added to it
            // then having that text saved into a file then loading that text back into the text box.

            // Add more text to the already filled text box
            // Save text to file
            // Load text into text box
            // Test to see if the text in text box matches the string created earlier
            Assert.AreEqual(
                "",
                this.testWindow.ActiveControl.Text);
        }

        /// <summary>
        /// Test loading a Fibonacci sequence into a text box.
        /// </summary>
        [Test]
        public void TestFibonacci()
        {
            string fib25 =
                "1: 0\r\n2: 1\r\n3: 1\r\n4: 2\r\n5: 3\r\n6: 5\r\n7: 8\r\n8: 13\r\n9: 21\r\n10: 34\r\n" +
                "11: 55\r\n12: 89\r\n13: 144\r\n14: 233\r\n15: 377\r\n16: 610\r\n17: 987\r\n18: 1597\r\n19: 2584\r\n20: 4181\r\n" +
                "21: 6765\r\n22: 10946\r\n23: 17711\r\n24: 28657\r\n25: 46368\r\n";

            FibonacciTextReader testFib = new FibonacciTextReader(25);
            MethodInfo mInfo = this.GetMethod("LoadText");
            mInfo.Invoke(this.testWindow, new object[] { testFib });
            Assert.AreEqual(
                fib25,
                this.testWindow.ActiveControl.Text);

        }

        /// <summary>
        /// Getter for methods.
        /// </summary>
        /// <param name="methodName">
        /// The name of the method you are trying to get.
        /// </param>
        /// <returns>
        /// MethodInfo of the method methodName.
        /// </returns>
        private MethodInfo GetMethod(string methodName)
        {
            if (string.IsNullOrWhiteSpace(methodName))
            {
                Assert.Fail("method Name cannot be null or whitespace");
            }

            var method = this.testWindow.GetType().GetMethod(
                methodName,
                BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);

            if (method == null)
            {
                Assert.Fail(string.Format("{0} method not found", methodName));
            }

            return method;
        }
    }
}
