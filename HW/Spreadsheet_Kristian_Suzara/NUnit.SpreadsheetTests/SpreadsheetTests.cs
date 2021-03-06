// <copyright file="SpreadsheetTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NUnit.SpreadsheetTests
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
    public class SpreadsheetTests
    {
        /// <summary>
        /// Test the creation of a spreadsheet and if the size matches the inputs.
        /// </summary>
        [Test]
        public void TestSpreadsheetSize()
        {
            Spreadsheet testSpreadSheet = new Spreadsheet(20, 5);

            // Test if the number of rows is correct.
            Assert.AreEqual(
                20,
                testSpreadSheet.RowCount);

            // Test if the amount of columns is correct.
            Assert.AreEqual(
                5,
                testSpreadSheet.ColumnCount);
        }

        /// <summary>
        /// Test for values within the cells of the spreadsheet.
        /// </summary>
        [Test]
        public void TestSpreadsheetValue()
        {
            Spreadsheet testSpreadSheet = new Spreadsheet(5, 5);

            // Test spreadsheet cell value when empty
            Assert.AreEqual(
                string.Empty,
                testSpreadSheet.GetCell(0, 0).Value);

            // Test spreadsheet cell value after text is set on initially empty cell
            testSpreadSheet.GetCell(0, 0).Text = "wow";
            Assert.AreEqual(
                "wow",
                testSpreadSheet.GetCell(0, 0).Value);

            // Test spreadsheet cell value after more text is added to a non empty cell
            testSpreadSheet.GetCell(0, 0).Text += " amazing";
            Assert.AreEqual(
                "wow amazing",
                testSpreadSheet.GetCell(0, 0).Value);

            // Test spreadsheet cell value when it starts with an '=' and is referencing an empty cell
            testSpreadSheet.GetCell(4, 4).Text = "=B1";
            Assert.AreEqual(
                string.Empty,
                testSpreadSheet.GetCell(0, 1).Value);

            // Test spreadsheet cell value when it starts with an '=' and is referencing a non empty cell
            testSpreadSheet.GetCell(0, 1).Text = "=A1";
            Assert.AreEqual(
                "wow amazing",
                testSpreadSheet.GetCell(0, 1).Value);
        }

        /// <summary>
        /// Test for texts within the cells of the spreadsheet.
        /// </summary>
        [Test]
        public void TestSpreadsheetText()
        {
            Spreadsheet testSpreadSheet = new Spreadsheet(5, 5);

            // Test spreadsheet cell text when empty
            Assert.AreEqual(
                string.Empty,
                testSpreadSheet.GetCell(0, 0).Text);

            // Test spreadsheet cell text after text is set on initially empty cell
            testSpreadSheet.GetCell(0, 0).Text = "wow";
            Assert.AreEqual(
                "wow",
                testSpreadSheet.GetCell(0, 0).Text);

            // Test spreadsheet cell text after more text is added to a non empty cell
            testSpreadSheet.GetCell(0, 0).Text += " amazing";
            Assert.AreEqual(
                "wow amazing",
                testSpreadSheet.GetCell(0, 0).Text);
        }
    }
}
