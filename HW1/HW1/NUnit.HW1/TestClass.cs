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
    }
}
