// <copyright file="ExpressionTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NUnit.ExpressionTests
{
    using System.Collections;
    using System.Collections.Generic;
    using global::CptS321;
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
            testTree.SetVariable("A", 5.0);
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

        /// <summary>
        /// Test ExpressionTree addition from evaluate.
        /// </summary>
        [Test]
        public void TestExpressionTreeAdd()
        {
            // test normal addition between two values
            ExpressionTree testTree = new ExpressionTree("5+5");
            Assert.AreEqual(
                10.0,
                testTree.Evaluate());

            // test normal addition between a positive variable and a value
            testTree = new ExpressionTree("A1+15");
            testTree.SetVariable("A1", 5.0);
            Assert.AreEqual(
                20.0,
                testTree.Evaluate());

            // test normal addition between a negative variable and a value
            testTree.SetVariable("A1", -5.0);
            Assert.AreEqual(
                10.0,
                testTree.Evaluate());

            // test addition between a variable at max value and a value
            testTree.SetVariable("A1", double.MaxValue);
            Assert.AreEqual(
                double.MaxValue,
                testTree.Evaluate());

            // test addition between a variable at min value and a value
            testTree.SetVariable("A1", double.MinValue);
            Assert.AreEqual(
                double.MinValue,
                testTree.Evaluate());

            // test addition between a variable at positive infinity and a value
            testTree.SetVariable("A1", double.PositiveInfinity);
            Assert.AreEqual(
                double.PositiveInfinity,
                testTree.Evaluate());

            // test addition between a variable at negatuve infinity and a value
            testTree.SetVariable("A1", double.NegativeInfinity);
            Assert.AreEqual(
                double.NegativeInfinity,
                testTree.Evaluate());

            // test normal addition between a positive variable and a positive variable
            testTree = new ExpressionTree("A1+B1");
            testTree.SetVariable("A1", 5.0);
            testTree.SetVariable("B1", 10.0);
            Assert.AreEqual(
                15.0,
                testTree.Evaluate());

            // test normal addition between a negative variable and a negative variable
            testTree.SetVariable("A1", -5.0);
            testTree.SetVariable("B1", -10.0);
            Assert.AreEqual(
                -15.0,
                testTree.Evaluate());

            // test normal addition between a positive variable and a negative variable
            testTree.SetVariable("A1", 5.0);
            testTree.SetVariable("B1", -10.0);
            Assert.AreEqual(
                -5.0,
                testTree.Evaluate());

            // test normal addition between a negative variable and a positive variable
            testTree.SetVariable("A1", -5.0);
            testTree.SetVariable("B1", 10.0);
            Assert.AreEqual(
                5.0,
                testTree.Evaluate());

            // test addition between two variables at max value
            testTree.SetVariable("A1", double.MaxValue);
            testTree.SetVariable("B1", double.MaxValue);
            Assert.AreEqual(
                double.PositiveInfinity,
                testTree.Evaluate());

            // test addition between two variables at min value
            testTree.SetVariable("A1", double.MinValue);
            testTree.SetVariable("B1", double.MinValue);
            Assert.AreEqual(
                double.NegativeInfinity,
                testTree.Evaluate());

            // test addition between a variable at max value and a variable at min value
            testTree.SetVariable("A1", double.MaxValue);
            testTree.SetVariable("B1", double.MinValue);
            Assert.AreEqual(
                0,
                testTree.Evaluate());

            // test addition between a variable at min value and a variable at max value
            testTree.SetVariable("A1", double.MinValue);
            testTree.SetVariable("B1", double.MaxValue);
            Assert.AreEqual(
                0,
                testTree.Evaluate());

            // test addition between two variables at positive infinity
            testTree.SetVariable("A1", double.PositiveInfinity);
            testTree.SetVariable("B1", double.PositiveInfinity);
            Assert.AreEqual(
                double.PositiveInfinity,
                testTree.Evaluate());

            // test addition between two variables at negative infinity
            testTree.SetVariable("A1", double.NegativeInfinity);
            testTree.SetVariable("B1", double.NegativeInfinity);
            Assert.AreEqual(
                double.NegativeInfinity,
                testTree.Evaluate());

            // test addition between a variable at positive infinity and a variable at negative infinity
            testTree.SetVariable("A1", double.PositiveInfinity);
            testTree.SetVariable("B1", double.NegativeInfinity);
            Assert.AreEqual(
                double.NaN,
                testTree.Evaluate());

            // test addition between a variable at negative infinity and a variable at positive infinity
            testTree.SetVariable("A1", double.NegativeInfinity);
            testTree.SetVariable("B1", double.PositiveInfinity);
            Assert.AreEqual(
                double.NaN,
                testTree.Evaluate());
        }

        /// <summary>
        /// Test ExpressionTree subtraction from evaluate.
        /// </summary>
        [Test]
        public void TestExpressionTreeSub()
        {
            // test normal subtraction between two values
            ExpressionTree testTree = new ExpressionTree("5-5");
            Assert.AreEqual(
                0.0,
                testTree.Evaluate());

            // test normal subtraction between a positive variable and a value
            testTree = new ExpressionTree("A1-15");
            testTree.SetVariable("A1", 5.0);
            Assert.AreEqual(
                -10.0,
                testTree.Evaluate());

            // test normal subtraction between a negative variable and a value
            testTree.SetVariable("A1", -5.0);
            Assert.AreEqual(
                -20.0,
                testTree.Evaluate());

            // test subtraction between a variable at max value and a value
            testTree.SetVariable("A1", double.MaxValue);
            Assert.AreEqual(
                double.MaxValue,
                testTree.Evaluate());

            // test subtraction between a variable at min value and a value
            testTree.SetVariable("A1", double.MinValue);
            Assert.AreEqual(
                double.MinValue,
                testTree.Evaluate());

            // test subtraction between a variable at positive infinity and a value
            testTree.SetVariable("A1", double.PositiveInfinity);
            Assert.AreEqual(
                double.PositiveInfinity,
                testTree.Evaluate());

            // test subtraction between a variable at negatuve infinity and a value
            testTree.SetVariable("A1", double.NegativeInfinity);
            Assert.AreEqual(
                double.NegativeInfinity,
                testTree.Evaluate());

            // test normal subtraction between a positive variable and a positive variable
            testTree = new ExpressionTree("A1-B1");
            testTree.SetVariable("A1", 5.0);
            testTree.SetVariable("B1", 10.0);
            Assert.AreEqual(
                -5.0,
                testTree.Evaluate());

            // test normal subtraction between a negative variable and a negative variable
            testTree.SetVariable("A1", -5.0);
            testTree.SetVariable("B1", -10.0);
            Assert.AreEqual(
                5.0,
                testTree.Evaluate());

            // test normal subtraction between a positive variable and a negative variable
            testTree.SetVariable("A1", 5.0);
            testTree.SetVariable("B1", -10.0);
            Assert.AreEqual(
                15.0,
                testTree.Evaluate());

            // test normal subtraction between a negative variable and a positive variable
            testTree.SetVariable("A1", -5.0);
            testTree.SetVariable("B1", 10.0);
            Assert.AreEqual(
                -15.0,
                testTree.Evaluate());

            // test subtraction between two variables at max value
            testTree.SetVariable("A1", double.MaxValue);
            testTree.SetVariable("B1", double.MaxValue);
            Assert.AreEqual(
                0,
                testTree.Evaluate());

            // test subtraction between two variables at min value
            testTree.SetVariable("A1", double.MinValue);
            testTree.SetVariable("B1", double.MinValue);
            Assert.AreEqual(
                0,
                testTree.Evaluate());

            // test subtraction between a variable at max value and a variable at min value
            testTree.SetVariable("A1", double.MaxValue);
            testTree.SetVariable("B1", double.MinValue);
            Assert.AreEqual(
                double.PositiveInfinity,
                testTree.Evaluate());

            // test subtraction between a variable at min value and a variable at max value
            testTree.SetVariable("A1", double.MinValue);
            testTree.SetVariable("B1", double.MaxValue);
            Assert.AreEqual(
                double.NegativeInfinity,
                testTree.Evaluate());

            // test subtraction between two variables at positive infinity
            testTree.SetVariable("A1", double.PositiveInfinity);
            testTree.SetVariable("B1", double.PositiveInfinity);
            Assert.AreEqual(
                double.NaN,
                testTree.Evaluate());

            // test subtraction between two variables at negative infinity
            testTree.SetVariable("A1", double.NegativeInfinity);
            testTree.SetVariable("B1", double.NegativeInfinity);
            Assert.AreEqual(
                double.NaN,
                testTree.Evaluate());

            // test subtraction between a variable at positive infinity and a variable at negative infinity
            testTree.SetVariable("A1", double.PositiveInfinity);
            testTree.SetVariable("B1", double.NegativeInfinity);
            Assert.AreEqual(
                double.PositiveInfinity,
                testTree.Evaluate());

            // test subtraction between a variable at negative infinity and a variable at positive infinity
            testTree.SetVariable("A1", double.NegativeInfinity);
            testTree.SetVariable("B1", double.PositiveInfinity);
            Assert.AreEqual(
                double.NegativeInfinity,
                testTree.Evaluate());
        }

        /// <summary>
        /// Test ExpressionTree multiplication from evaluate.
        /// </summary>
        [Test]
        public void TestExpressionTreeMul()
        {
            // test normal multiplication between two values
            ExpressionTree testTree = new ExpressionTree("5*5");
            Assert.AreEqual(
                25.0,
                testTree.Evaluate());

            // test normal multiplication between a positive variable and a value
            testTree = new ExpressionTree("A1*15");
            testTree.SetVariable("A1", 5.0);
            Assert.AreEqual(
                75.0,
                testTree.Evaluate());

            // test normal multiplication between a negative variable and a value
            testTree.SetVariable("A1", -5.0);
            Assert.AreEqual(
                -75.0,
                testTree.Evaluate());

            // test multiplication between a variable at max value and a value
            testTree.SetVariable("A1", double.MaxValue);
            Assert.AreEqual(
                double.PositiveInfinity,
                testTree.Evaluate());

            // test multiplication between a variable at min value and a value
            testTree.SetVariable("A1", double.MinValue);
            Assert.AreEqual(
                double.NegativeInfinity,
                testTree.Evaluate());

            // test multiplication between a variable at positive infinity and a value
            testTree.SetVariable("A1", double.PositiveInfinity);
            Assert.AreEqual(
                double.PositiveInfinity,
                testTree.Evaluate());

            // test multiplication between a variable at negatuve infinity and a value
            testTree.SetVariable("A1", double.NegativeInfinity);
            Assert.AreEqual(
                double.NegativeInfinity,
                testTree.Evaluate());

            // test normal multiplication between a positive variable and a positive variable
            testTree = new ExpressionTree("A1*B1");
            testTree.SetVariable("A1", 5.0);
            testTree.SetVariable("B1", 10.0);
            Assert.AreEqual(
                50.0,
                testTree.Evaluate());

            // test normal multiplication between a negative variable and a negative variable
            testTree.SetVariable("A1", -5.0);
            testTree.SetVariable("B1", -10.0);
            Assert.AreEqual(
                50.0,
                testTree.Evaluate());

            // test normal multiplication between a positive variable and a negative variable
            testTree.SetVariable("A1", 5.0);
            testTree.SetVariable("B1", -10.0);
            Assert.AreEqual(
                -50.0,
                testTree.Evaluate());

            // test normal multiplication between a negative variable and a positive variable
            testTree.SetVariable("A1", -5.0);
            testTree.SetVariable("B1", 10.0);
            Assert.AreEqual(
                -50.0,
                testTree.Evaluate());

            // test multiplication between two variables at max value
            testTree.SetVariable("A1", double.MaxValue);
            testTree.SetVariable("B1", double.MaxValue);
            Assert.AreEqual(
                double.PositiveInfinity,
                testTree.Evaluate());

            // test multiplication between two variables at min value
            testTree.SetVariable("A1", double.MinValue);
            testTree.SetVariable("B1", double.MinValue);
            Assert.AreEqual(
                double.PositiveInfinity,
                testTree.Evaluate());

            // test multiplication between a variable at max value and a variable at min value
            testTree.SetVariable("A1", double.MaxValue);
            testTree.SetVariable("B1", double.MinValue);
            Assert.AreEqual(
                double.NegativeInfinity,
                testTree.Evaluate());

            // test multiplication between a variable at min value and a variable at max value
            testTree.SetVariable("A1", double.MinValue);
            testTree.SetVariable("B1", double.MaxValue);
            Assert.AreEqual(
                double.NegativeInfinity,
                testTree.Evaluate());

            // test multiplication between two variables at positive infinity
            testTree.SetVariable("A1", double.PositiveInfinity);
            testTree.SetVariable("B1", double.PositiveInfinity);
            Assert.AreEqual(
                double.PositiveInfinity,
                testTree.Evaluate());

            // test multiplication between two variables at negative infinity
            testTree.SetVariable("A1", double.NegativeInfinity);
            testTree.SetVariable("B1", double.NegativeInfinity);
            Assert.AreEqual(
                double.PositiveInfinity,
                testTree.Evaluate());

            // test multiplication between a variable at positive infinity and a variable at negative infinity
            testTree.SetVariable("A1", double.PositiveInfinity);
            testTree.SetVariable("B1", double.NegativeInfinity);
            Assert.AreEqual(
                double.NegativeInfinity,
                testTree.Evaluate());

            // test multiplication between a variable at negative infinity and a variable at positive infinity
            testTree.SetVariable("A1", double.NegativeInfinity);
            testTree.SetVariable("B1", double.PositiveInfinity);
            Assert.AreEqual(
                double.NegativeInfinity,
                testTree.Evaluate());
        }

        /// <summary>
        /// Test ExpressionTree division from evaluate.
        /// </summary>
        [Test]
        public void TestExpressionTreeDiv()
        {
            // test normal division between two values
            ExpressionTree testTree = new ExpressionTree("5/5");
            Assert.AreEqual(
                1.0,
                testTree.Evaluate());

            // test normal division between a positive variable and a value
            testTree = new ExpressionTree("A1/10");
            testTree.SetVariable("A1", 5.0);
            Assert.AreEqual(
                0.5,
                testTree.Evaluate());

            // test normal division between a negative variable and a value
            testTree.SetVariable("A1", -5.0);
            Assert.AreEqual(
                -0.5,
                testTree.Evaluate());

            // test division between a variable at max value and a value
            testTree.SetVariable("A1", double.MaxValue);
            Assert.AreEqual(
                double.MaxValue / 10,
                testTree.Evaluate());

            // test division between a variable at min value and a value
            testTree.SetVariable("A1", double.MinValue);
            Assert.AreEqual(
                double.MinValue / 10,
                testTree.Evaluate());

            // test division between a variable at positive infinity and a value
            testTree.SetVariable("A1", double.PositiveInfinity);
            Assert.AreEqual(
                double.PositiveInfinity,
                testTree.Evaluate());

            // test division between a variable at negatuve infinity and a value
            testTree.SetVariable("A1", double.NegativeInfinity);
            Assert.AreEqual(
                double.NegativeInfinity,
                testTree.Evaluate());

            // test normal division between a positive variable and a positive variable
            testTree = new ExpressionTree("A1/B1");
            testTree.SetVariable("A1", 5.0);
            testTree.SetVariable("B1", 10.0);
            Assert.AreEqual(
                0.5,
                testTree.Evaluate());

            // test normal division between a negative variable and a negative variable
            testTree.SetVariable("A1", -5.0);
            testTree.SetVariable("B1", -10.0);
            Assert.AreEqual(
                0.5,
                testTree.Evaluate());

            // test normal division between a positive variable and a negative variable
            testTree.SetVariable("A1", 5.0);
            testTree.SetVariable("B1", -10.0);
            Assert.AreEqual(
                -0.5,
                testTree.Evaluate());

            // test normal division between a negative variable and a positive variable
            testTree.SetVariable("A1", -5.0);
            testTree.SetVariable("B1", 10.0);
            Assert.AreEqual(
                -0.5,
                testTree.Evaluate());

            // test division between two variables at max value
            testTree.SetVariable("A1", double.MaxValue);
            testTree.SetVariable("B1", double.MaxValue);
            Assert.AreEqual(
                1,
                testTree.Evaluate());

            // test division between two variables at min value
            testTree.SetVariable("A1", double.MinValue);
            testTree.SetVariable("B1", double.MinValue);
            Assert.AreEqual(
                1,
                testTree.Evaluate());

            // test division between a variable at max value and a variable at min value
            testTree.SetVariable("A1", double.MaxValue);
            testTree.SetVariable("B1", double.MinValue);
            Assert.AreEqual(
                -1,
                testTree.Evaluate());

            // test division between a variable at min value and a variable at max value
            testTree.SetVariable("A1", double.MinValue);
            testTree.SetVariable("B1", double.MaxValue);
            Assert.AreEqual(
                -1,
                testTree.Evaluate());

            // test division between two variables at positive infinity
            testTree.SetVariable("A1", double.PositiveInfinity);
            testTree.SetVariable("B1", double.PositiveInfinity);
            Assert.AreEqual(
                double.NaN,
                testTree.Evaluate());

            // test division between two variables at negative infinity
            testTree.SetVariable("A1", double.NegativeInfinity);
            testTree.SetVariable("B1", double.NegativeInfinity);
            Assert.AreEqual(
                double.NaN,
                testTree.Evaluate());

            // test division between a variable at positive infinity and a variable at negative infinity
            testTree.SetVariable("A1", double.PositiveInfinity);
            testTree.SetVariable("B1", double.NegativeInfinity);
            Assert.AreEqual(
                double.NaN,
                testTree.Evaluate());

            // test division between a variable at negative infinity and a variable at positive infinity
            testTree.SetVariable("A1", double.NegativeInfinity);
            testTree.SetVariable("B1", double.PositiveInfinity);
            Assert.AreEqual(
                double.NaN,
                testTree.Evaluate());
        }
    }
}