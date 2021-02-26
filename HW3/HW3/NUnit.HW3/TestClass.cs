// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace NUnit.HW3
{
    [TestFixture]
    public class TestClass
    {
        /// <summary>
        /// Test saving and loading a file into a text box.
        /// </summary>
        [Test]
        public void TestSaveLoad()
        { 
            // Test 1 is dealing with an initially empty text box having text added to it
            // then having that text saved into a file then loading that text back into the text box.


            // Set up a file
            // Create a string and set it into an initially empty text box
            // Save text to file
            // Set up initial file again after the text was saved
            // Empty up the text box
            // Load text into text box
            // Test to see if the text in text box matches the string created earlier
            Assert.AreEqual(
                "wow",
                this.TextBox.Text);

            // Test 2 is dealing with an already filled text box having more text added to it
            // then having that text saved into a file then loading that text back into the text box.

            // Add more text to the already filled text box
            // Save text to file
            // Load text into text box
            // Test to see if the text in text box matches the string created earlier
            Assert.AreEqual(
                "wow it happened again",
                this.TextBox.Text);
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
            Load(testFib);
            Assert.AreEqual(
                fib25,
                this.TextBox.Text);

        }
    }
}
