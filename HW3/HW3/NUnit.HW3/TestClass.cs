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
    }
}
