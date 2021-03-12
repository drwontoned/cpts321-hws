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
    }
}