// <copyright file="ExpressionTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NUnit.ExpressionTests
{
    using System.Collections;
    using System.Collections.Generic;
    using global::Spreadsheet_Kristian_Suzara;
    using global::SpreadsheetEngine;

    using NUnit.Framework;

    /// <summary>
    /// Class with tests for the spreadsheet.
    /// </summary>
    [TestFixture]
    public class ExpressionTests
    {
        /// <summary>
        /// Test if expression gets changed.
        /// </summary>
        [Test]
        public void TestChangeExpression()
        {
            ExpressionTree testTree = new ExpressionTree("A+1+B+2"); 

            // Test initial expression
            Assert.AreEqual(
                "A+1+B+2",
                testTree.Expression);

            // Test if expression is changed
            testTree = new ExpressionTree("C-3-D-4");
            Assert.AreEqual(
                "C-3-D-4",
                testTree.Expression);
        }

        /// <summary>
        /// Test if variable value gets set.
        /// </summary>
        [Test]
        public void TestSetVariable()
        {
            ExpressionTree testTree = new ExpressionTree("A+1");

            // Test value of a variable before it is set by pulling it from dictionary
            Assert.AreEqual(
                0.0,
                testTree.GetVariableValue("A"));

            // Test value of a variable after it is set
            testTree.SetVariable("A", 5,0);
            Assert.AreEqual(
               5.0,
                testTree.GetVariableValue("A"));

            // Test value if value is just over the MaxValue (should just round down to max)
            testTree.SetVariable("A", double.MaxValue + 5);
            Assert.AreEqual(
               double.MaxValue,
                testTree.GetVariableValue("A"));

            // Test value if value is much larger than MaxValue (should be positive infinity)
            testTree.SetVariable("A", double.MaxValue * 5);
            Assert.AreEqual(
               double.PositiveInfinity,
                testTree.GetVariableValue("A"));

            // Test value if value is just over the MinValue (should just round up to min)
            testTree.SetVariable("A", double.MinValue - 5);
            Assert.AreEqual(
               double.MinValue,
                testTree.GetVariableValue("A"));

            // Test value if value is much larger than MinValue (should be negative infinity)
            testTree.SetVariable("A", double.MinValue * 5);
            Assert.AreEqual(
               double.NegativeInfinity,
                testTree.GetVariableValue("A"));
        }
    }
}